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
            add_round_key(ref data);

            int round_counter = this.round_num - 1;         // prva runda je bila samo add_round_key()

            do
            {
                shift_rows(ref data);
                sub_bytes(ref data);
                add_round_key(ref data);
                mix_columns(ref data);

                round_counter--;        // Prosla je jedna runda;
            } while (round_counter > 0);

            // poslednji prolaz, bez mesanja kolona, po opisu algoritma:
            shift_rows(ref data);
            sub_bytes(ref data);
            add_round_key(ref data);

            // Upis rezultata u binarni fajl [OK];
            BinaryWriter br = new BinaryWriter(File.Open(file, FileMode.Create));
            foreach(byte b in data)
            {
                br.Write(b);
            }

            br.Flush();
            br.Close();

            Console.WriteLine("\nReturning data: ");
            print_data(data);

            // Vracanje rezultata, ukoliko nam treba?
            return data;
        }

        public byte[,] decrypt(byte[,] data)
        {
            return data;
        }

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
                    byte y_pos = (byte)((j + ((this.key_bytes / 4) - i)) % (this.key_bytes / 4));
                    tmp[j] = data[i, y_pos];
                }

                // Sada vrsimo zamenu redova:
                for(int j = 0; j < this.key_bytes / 4; j++)
                {
                    data[i, j] = tmp[j];
                }
            }

            // Return data [OK]
            //return data;
        }

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
                vec[i] = (byte)(gfmultby02(data[index_mat[i, 0], 1]) + gfmultby01(data[index_mat[i, 1], 1]) + gfmultby01(data[index_mat[i, 2], 1]) + gfmultby03(data[index_mat[i, 3], 1]));
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
        protected void add_round_key(ref byte[,] data)
        {
            // Da ne bi pravio novu promenljivu, fiksno, menja se byte na poziciji mat[3, 3];
            // A i radi za sve duzine kljuceva, tako da je to tako:

            // XOR on position [3, 3] [OK]

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

    }

}
