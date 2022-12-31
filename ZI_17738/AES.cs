using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZI_17738
{
    internal class AES
    {
        protected byte[] key;
        protected int key_bytes;
        protected int round_num;

        protected byte[,] key_matrix;           // Kljuc pretvoren u matricu, odgovarajuce dimenzije [4x4 || 4x6 || 4x8]
        protected byte[,] sub_byte_mat;         // Matrica za prvi korak, za preslikavanje prilikom kodiranja
        protected byte[,] sub_byte_inverse;     // Matrica za preslikavanje prilikom dekodiranja

        public AES()
        {

        }

        public AES(int key_size, byte[] key)
        {
            // Fiksne vrednosti, kako bi znali granice [OK]
            this.key = key;                         // Kljuc kao niz 8b vrednosti;
            this.key_bytes = key_size;              // Velicina kljuca u B [128, 192, 256];
            this.round_num = 6 + (key_size / 4);    // Broj rundi na osnovu velicine kljuca, magicna formula :)

            // Zbog preglednosti su ucitane ovako, kod deluje mnogo konfuzno sa njima;
            load_matrix("F:\\zi\\first_mat.bin", "F:\\zi\\seccond_mat.bin");

            // Key Byte Array [OK]
            this.key = key;

            // Key Byte Matrix [OK]
            int counter = 0;
            this.key_matrix = new byte[4, key_size / 4]; 
            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < key_size / 4; j++)
                {
                    this.key_matrix[i, j] = this.key[counter++];
                }
            }

        }

        public void load_matrix(string mat, string inv_mat)
        {
            // Inicijalizovanje obe look-up tabele na osnovu imena binarnih fajlova:
            byte[] buff = File.ReadAllBytes(mat);
            byte[] buff2 = File.ReadAllBytes(inv_mat);

            int counter = 0;
            this.sub_byte_mat = new byte[16, 16];
            this.sub_byte_inverse = new byte[16, 16];
            for(int i = 0; i < 16; i++)
            {
                for(int j = 0; j < 16; j++)
                {
                    this.sub_byte_mat[i, j] = buff[counter];
                    this.sub_byte_inverse[i, j] = buff2[counter++];
                }
            }

        }

        public byte[,] encrypt(byte[,] data, string file)
        {
            Console.WriteLine("Got data: ");
            print_data(data);
            // Inicijalno, prva runda samo radi ovo, po definiciji AES-a:
            add_round_key(ref data, 0);

            int round_counter = this.round_num;         // prva runda je bila samo add_round_key()

            for (int round = 1; round <= this.round_num - 1; ++round)
            {

                sub_bytes(ref data);
                shift_rows(ref data);
                //mix_columns(ref data);
                add_round_key(ref data, round);

                Console.WriteLine("Encrypting round: " + round);
                print_data(data);
            }

            // poslednji prolaz, bez mesanja kolona, po opisu algoritma:
            sub_bytes(ref data);
            shift_rows(ref data);
            add_round_key(ref data, this.round_num);

            // Upis rezultata u binarni fajl [OK];
            BinaryWriter br = new BinaryWriter(File.Open(file, FileMode.Create));
            foreach(byte b in data)
            {
                br.Write(b);
            }

            br.Flush();
            br.Close();

            Console.WriteLine("Encrypter round final: ");
            print_data(data);

            //Console.WriteLine("\nReturning data: ");
            //print_data(data);

            // Vracanje rezultata, ukoliko nam treba?
            return data;
        }

        public byte[,] decrypt(string file)
        {
            //Console.WriteLine("Got data: ");
            //print_data(data);

            // Readnig data from file: [OK]
            byte[] buff = File.ReadAllBytes(file);

            // Creating data matrix: [OK]
            byte[,] data = new byte[4, this.key_bytes / 4]; 
            int counter = 0;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < this.key_bytes / 4; j++)
                {
                    data[i, j] = (byte)(buff[counter++]);
                }
            }

            // Inicijalno, prva runda samo radi ovo, po definiciji AES-a:
            add_round_key(ref data, this.round_num);

            int round_counter = this.round_num;         // prva runda je bila samo add_round_key()

            for(int round = this.round_num-1; round >= 1; --round)
            {


                inverted_shift_rows(ref data);
                inverted_sub_bytes(ref data);

                Console.WriteLine("Decrypting round: " + round);
                print_data(data);
                
                add_round_key(ref data, round);
                
                //inverted_mix_columns(ref data);

                //Console.WriteLine("Decrypt round: " + round);
                //print_data(data);
            }

            // poslednji prolaz, bez mesanja kolona, po opisu algoritma:
            inverted_shift_rows(ref data);
            inverted_sub_bytes(ref data);
            add_round_key(ref data, 0);

            Console.WriteLine("Decrypter round final: ");
            print_data(data);

            // Pretvaranje rezultata nazad u string [OK]:

            buff = new byte[this.key_bytes];
            counter = 0;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < this.key_bytes / 4; j++)
                {
                    buff[counter++] = (byte)data[i, j];
                }
            }

            string result = Encoding.ASCII.GetString(buff);
            Console.WriteLine("Decoded data: " + result);

            // Vracanje rezultata, ukoliko nam treba?
            return data;
        }

        #region SubBytes

        // [OK]
        protected void sub_bytes(ref byte[,] data)
        {
            // Nested for loops for changing values [OK]
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < this.key_bytes / 4; j++)
                {
                    // Izvlacenje nizih i visih 4b sadrzaja (poput rada sa registrima) bajta:
                    byte lower_reg = (byte)(data[i, j] & 0x0F);
                    byte upper_reg = (byte)(data[i, j] >> 4);

                    // Zamena polja odgovarajucom vrednoscu iz look-up tabele:
                    data[i, j] = (byte)(this.sub_byte_mat[upper_reg, lower_reg]);
                }
            }

            // Return data [OK]
            //return data;
        }
        // [OK]
        protected void inverted_sub_bytes(ref byte[,] data)
        {
            // Nested for loops for changing values [OK]
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < this.key_bytes / 4; j++)
                {
                    // Izvlacenje nizih i visih 4b sadrzaja (poput rada sa registrima) bajta:
                    byte lower_reg = (byte)(data[i, j] & 0x0F);
                    byte upper_reg = (byte)(data[i, j] >> 4);

                    // Zamena polja odgovarajucom vrednoscu iz look-up tabele:
                    data[i, j] = (byte)(this.sub_byte_inverse[upper_reg, lower_reg]);
                }
            }

            // Return data [OK]
            //return data;
        }

        #endregion

        #region Shift

        // [OK]
        protected void shift_rows(ref byte[,] data)
        {
            // Shifting [OK]: 
            //int[] shift_count = { 1, 2, 3 };
            byte[] tmp = new byte[this.key_bytes / 4];

            for(int i = 1; i < 4; i++)
            {
                // Prvo vrsimo rotiranje niza, ne pitaj za formulu, bukvalno sam 200 puta imao muku sa tim, napamet je znam
                for(int j = 0; j < this.key_bytes / 4; j++)
                {
                    tmp[j] = data[i, j];
                }

                // Sada vrsimo zamenu redova:
                for(int j = 0; j < this.key_bytes / 4; j++)
                {
                    data[i, j] = tmp[(i + j) % (this.key_bytes / 4)];
                }
            }

            // Return data [OK]
            //return data;
        }
        // [OK]
        protected void inverted_shift_rows(ref byte[,] data)
        {
            // Shifting [OK]: 
            //int[] shift_count = { 1, 2, 3 };
            byte[] tmp = new byte[this.key_bytes / 4];

            for (int i = 1; i < 4; i++)
            {
                // Prvo vrsimo rotiranje niza, ne pitaj za formulu, bukvalno sam 200 puta imao muku sa tim, napamet je znam
                for (int j = 0; j < this.key_bytes / 4; j++)
                {
                    tmp[j] = data[i, j];
                }

                // Sada vrsimo zamenu redova:
                for (int j = 0; j < this.key_bytes / 4; j++)
                {
                    data[i, (j + i) % (this.key_bytes / 4)] = tmp[j];
                }
            }

            // Return data [OK]
            //return data;
        }

        #endregion

        #region Mix

        // [OK]
        protected void mix_columns(ref byte[,] data)
        {
            // vrsimo generisanje vektora:
            byte[] vec = new byte[4];      // rezultujuci vektor
            
            // redosled mnozenja, cuvamo indekse reda: [OK]
            byte[,] index_mat = new byte[4, 4]
            {
                { 0, 3, 2, 1 },    //r0
                { 1, 0, 3, 2 },    //r1
                { 2, 1, 0, 3 },    //r2
                { 3, 2, 1, 0 }     //r3
            };

            // vrsimo mnozenje 2 vrste (index 1): [OK]
            for(int i = 0; i < 4; i++)
            {
                vec[i] = (byte)(gfmultby02(data[index_mat[i, 0], 1]) + gfmultby03(data[index_mat[i, 1], 1]) + gfmultby01(data[index_mat[i, 2], 1]) + gfmultby01(data[index_mat[i, 3], 1]));
            }

            // zamena vektora: [OK]
            for(int i = 0; i < 4; i++)
            {
                data[i, 1] = (byte)vec[i];
            }

            // Return data [OK]
            // return data;
        }
        // [OK]
        protected void inverted_mix_columns(ref byte[,] data)
        {
            // vrsimo generisanje vektora:
            byte[] vec = new byte[4];      // rezultujuci vektor

            // redosled mnozenja, cuvamo indekse reda: [OK]
            byte[,] index_mat = new byte[4, 4]
            {
                { 0, 3, 2, 1 },    //r0
                { 1, 0, 3, 2 },    //r1
                { 2, 1, 0, 3 },    //r2
                { 3, 2, 1, 0 }     //r3
            };

            // vrsimo mnozenje 2 vrste (index 1): [OK]
            for (int i = 0; i < 4; i++)
            {
                vec[i] = (byte)(gfmultby0e(data[index_mat[i, 0], 1]) + gfmultby0b(data[index_mat[i, 1], 1]) + gfmultby0d(data[index_mat[i, 2], 1]) + gfmultby09(data[index_mat[i, 3], 1]));
            }

            // zamena vektora: [OK]
            for (int i = 0; i < 4; i++)
            {
                data[i, 1] = (byte)vec[i];
            }

            // Return data [OK]
            // return data;
        }

        #endregion

        // [OK]
        protected void add_round_key(ref byte[,] data, int round)
        {
            // Da ne bi pravio novu promenljivu, fiksno, menja se byte na poziciji mat[3, 3];
            // A i radi za sve duzine kljuceva, tako da je to tako:

            // XOR on position [3, 3] [OK]

            //for(int i = 0; i < 4; i++)
            //{
            //    for(int j = 0; j < this.key_bytes / 4; j++)
            //    {
            //        data[i, j] = (byte)(data[i, j] ^ this.sub_byte_mat[i, j]);
            //    }
            //}

            data[3, 3] = (byte)(data[3, 3] ^ this.key_matrix[3, 3]);

            // Return data [OK]
            //return data;
        }
        // [OK]
        public void print_data(byte[,] data)
        {
            Console.WriteLine("Data matrix: ");
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < this.key_bytes / 4; j++)
                {
                    Console.Write(data[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        #region Multiplying

        private static byte gfmultby01(byte b)
        {
            return b;
        }

        private static byte gfmultby02(byte b)
        {
            if (b < 0x80)
                return (byte)(int)(b << 1);
            else
                return (byte)((int)(b << 1) ^ (int)(0x1b));
        }

        private static byte gfmultby03(byte b)
        {
            return (byte)((int)gfmultby02(b) ^ (int)b);
        }


        #endregion

        #region Inverse Multiplying

        private static byte gfmultby09(byte b)
        {
            return (byte)((int)gfmultby02(gfmultby02(gfmultby02(b))) ^
                (int)b);
        }

        private static byte gfmultby0b(byte b)
        {
            return (byte)((int)gfmultby02(gfmultby02(gfmultby02(b))) ^
                (int)gfmultby02(b) ^
                (int)b);
        }

        private static byte gfmultby0d(byte b)
        {
            return (byte)((int)gfmultby02(gfmultby02(gfmultby02(b))) ^
                (int)gfmultby02(gfmultby02(b)) ^
                (int)(b));
        }

        private static byte gfmultby0e(byte b)
        {
            return (byte)((int)gfmultby02(gfmultby02(gfmultby02(b))) ^
                (int)gfmultby02(gfmultby02(b)) ^
                (int)gfmultby02(b));
        }

        #endregion


    }

}
