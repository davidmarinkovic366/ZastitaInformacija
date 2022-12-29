using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZI_17738
{
    struct POSITION
    {
        public int X, Y;

        public POSITION(int x, int y)
        {
            this.X = x; this.Y = y;
        }
    }


    internal class PlayfairCipher
    {
        protected char[,] table;
        protected Dictionary<char, POSITION> dict = new Dictionary<char, POSITION>();
        protected string key_word;
        protected char letter;

        public PlayfairCipher()
        {
            this.key_word = "";
            this.table = new char[5, 5];
            this.letter = 'A';
        }

        public PlayfairCipher(string key)
        {
            key = key.ToUpper();
            this.key_word = key.ToUpper();
            key = new string(key.Distinct().ToArray());

            Console.WriteLine("Distinct key: " + key + "\n");

            this.table = new char[5, 5];
            this.letter = 'A';

            int character_pos = 0;

            // Popunjavamo tabelu:
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    // Dodajemo prvo slova kljucne reci:
                    if(character_pos < key.Length)
                    {
                        if (!dict.ContainsKey(key[character_pos]))
                        {
                            table[i, j] = key[character_pos];
                            dict[key[character_pos]] = new POSITION(i, j);
                        }
                        character_pos++;
                    }
                    else
                    {
                        bool added = false;
                        do
                        {
                            if (!dict.ContainsKey(letter))
                            {
                                table[i, j] = letter;
                                dict[letter] = new POSITION(i, j);
                                added = true;
                            }
                            letter++; //Krecemo se slovo po slovo kroz ASCII tabelu:
                            if (letter == 'I')
                                letter++;
                        } while (!added);
                    }
                }
            }

            Console.WriteLine("Table: ");
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Console.Write(table[i, j] + " ");
                }
                Console.WriteLine("");
            }

        }

        public string encrypt(string data)
        {

            data = data.ToUpper();
            data = data.Replace(" ", String.Empty);
            data = data.Replace("I", String.Empty);
            // FIXME: remove;
            Console.WriteLine("Editovan string: " + data);

            // Deljenje stringa na substringove duzine 2:
            string[] arr = null;
            while (!check_if_valid(ref data, ref arr))
            {
                data = reformat(data);
            }

            // Sad je lepo odradjeno, mozemo da pocnemo sa enkripcijom:
            Console.WriteLine("Nakon prepravke, string izgleda ovako: " + data + "\n\n");

            string encrypted_data = "";
            foreach(string s in arr)
            {
                string step = "";

                POSITION first = dict[s[0]];
                POSITION seccond = dict[s[1]];

                // Situacija kada imamo transpoziciju po koloni:
                if (first.X == seccond.X)
                {
                    step += table[first.X, (first.Y + 1) % 5];
                    step += table[seccond.X, (seccond.Y + 1) % 5];
                }
                // Situacija kada imamo transpoziciju po vrsti:
                else if(first.Y == seccond.Y)
                {
                    step += table[(first.X + 1) % 5, first.Y];
                    step += table[(seccond.X + 1) % 5, seccond.Y];
                }
                // Situacija kada imamo kvadrat:
                else
                {
                    step += table[first.X, seccond.Y];
                    step += table[seccond.X, first.Y];
                }

                encrypted_data += step;
            }

            Console.WriteLine("Encrypted data: " + encrypted_data);
            return encrypted_data; 
        }

        public string decrypt(string data)
        {
            data = data.ToUpper();
            string[] arr = data.Chunk(2).Select(x => new string(x)).ToArray();

            string decrypted_data = "";
            foreach(string s in arr)
            {

                string step = "";
                POSITION first = dict[s[0]];
                POSITION seccond = dict[s[1]];

                // Jedan iznad drugog, u istoj koloni:
                if(first.Y == seccond.Y)
                {
                    step += table[first.X == 0 ? 4 : (Math.Abs(first.X - 1)) % 5, first.Y];
                    step += table[seccond.X == 0 ? 4 : (Math.Abs(seccond.X - 1)) % 5, seccond.Y];
                }
                // Jedan pored drugog, u istom redu:
                else if(first.X == seccond.X)
                {
                    step += table[first.X, first.Y == 0 ? 4 : (Math.Abs(first.Y - 1)) % 5];
                    step += table[seccond.X, seccond.Y == 0 ? 4 : (Math.Abs(seccond.Y - 1)) % 5];
                }
                // Slucaj da se nalazi u kvadratu:
                else
                {
                    step += table[first.X, seccond.Y];
                    step += table[seccond.X, first.Y];
                }

                decrypted_data += step;
            }

            Console.WriteLine("Decrypted data: " + decrypted_data);
            return decrypted_data;
        }

        public string reformat(string data)
        {
            for(int i = 0; i < data.Length - 1; i++)
            {
                if (data[i] == data[i + 1])
                {
                    // Razdvajamo dva ista karaktera:
                    data = data.Insert(i + 1, "X");
                    return data;
                }
            }

            // Ako smo izasli, onda nema sta da se formatira, samo dodamo karakter na kraju:
            data += 'X';
            return data;
        }

        public bool check_if_valid(ref string data, ref string[] arr) 
        {
            string data_copy = String.Copy(data);
            // Ako imamo neparan broj, sigurno moramo da dodamo na kraju jos jedan karakter:
            // Mozda prodjemo bez pozivanja reformat?
            if (data_copy.Length % 2 != 0)
                data_copy += "X";

            arr = null;
            arr = data_copy.Chunk(2).Select(x => new string(x)).ToArray();

            foreach (string s in arr)
            {
                if (s[0] == s[1])
                    return false;
            }

            // Ako nismo vratili false, znaci da je dobro, samim tim je i string koji smo izmenili odgovarajuci!
            data = data_copy;
            return true;

        }

    }
}
