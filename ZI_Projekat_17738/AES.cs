using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZI_Projekat_17738
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
            this.key_bytes = key_size;              // Velicina kljuca u B [128/8, 192/8, 256/8];
            this.round_num = 6 + (key_size / 4);    // Broj rundi na osnovu velicine kljuca, magicna formula :)

            // Ucitavanje matrica za enkripciju/dekripciju, odvojeno u posebnu funkciju zbog preglednosti koda;
            load_matrix();

            // Key Byte Array [OK]
            this.key = key;

            // Key Byte Matrix [OK]
            int counter = 0;
            this.key_matrix = new byte[4, key_size / 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < key_size / 4; j++)
                {
                    this.key_matrix[i, j] = this.key[counter++];
                }
            }

        }

        public void load_matrix()
        {

            this.sub_byte_mat = new byte[16, 16]
            {
                /*         0     1     2     3     4     5     6     7     8     9     a     b     c     d     e     f */
		        /*0*/  {0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76},
		        /*1*/  {0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0},
		        /*2*/  {0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15},
		        /*3*/  {0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75},
		        /*4*/  {0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84},
		        /*5*/  {0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf},
		        /*6*/  {0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8},
		        /*7*/  {0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2},
		        /*8*/  {0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73},
		        /*9*/  {0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb},
		        /*a*/  {0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79},
		        /*b*/  {0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08},
		        /*c*/  {0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a},
		        /*d*/  {0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e},
		        /*e*/  {0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf},
		        /*f*/  {0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16}
            };

            this.sub_byte_inverse = new byte[16, 16]
            {
                /*         0     1     2     3     4     5     6     7     8     9     a     b     c     d     e     f */
				/*0*/  {0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb},
				/*1*/  {0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb},
				/*2*/  {0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e},
				/*3*/  {0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25},
				/*4*/  {0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92},
				/*5*/  {0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84},
				/*6*/  {0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06},
				/*7*/  {0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b},
				/*8*/  {0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73},
				/*9*/  {0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e},
				/*a*/  {0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b},
				/*b*/  {0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4},
				/*c*/  {0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f},
				/*d*/  {0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef},
				/*e*/  {0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61},
				/*f*/  {0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d}
            };

        }

        public byte[] encrypt(byte[] input_data, string file)
        {
            // Pretvaranje niza podataka u matricu, jer AES radi sa matricom:
            byte[,] data = new byte[4, this.key_bytes / 4];
            int counter = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < this.key_bytes / 4; j++)
                    data[i, j] = input_data[counter++];

            // Inicijalno, prva runda samo radi ovo, po definiciji AES-a:
            add_round_key(ref data, 0);

            int round_counter = this.round_num;         // prva runda je bila samo add_round_key()

            for (int round = 1; round <= this.round_num - 1; ++round)
            {

                sub_bytes(ref data);
                shift_rows(ref data);
                mix_columns(ref data);
                add_round_key(ref data, round);

            }

            // poslednji prolaz, bez mesanja kolona, po opisu algoritma:
            sub_bytes(ref data);
            shift_rows(ref data);
            add_round_key(ref data, this.round_num);

            // Upis rezultata u binarni fajl [OK];
            BinaryWriter br = new BinaryWriter(File.Open(file, FileMode.Create));
            foreach (byte b in data)
            {
                br.Write(b);
            }

            br.Flush();
            br.Close();


            byte[] buff = new byte[this.key_bytes];
            counter = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < this.key_bytes / 4; j++)
                    buff[counter++] = data[i, j];

            // Vracanje rezultata, ukoliko nam treba?
            return buff;
        }

        public byte[,] decrypt(string file)
        {

            // Readnig data from file: [OK]
            byte[] buff = File.ReadAllBytes(file);

            // Creating data matrix: [OK]
            byte[,] data = new byte[4, this.key_bytes / 4];
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < this.key_bytes / 4; j++)
                {
                    data[i, j] = (byte)(buff[counter++]);
                }
            }

            // Inicijalno, prva runda samo radi ovo, po definiciji AES-a:
            add_round_key(ref data, this.round_num);

            int round_counter = this.round_num;         // prva runda je bila samo add_round_key()

            for (int round = this.round_num - 1; round >= 1; --round)
            {


                inverted_shift_rows(ref data);
                inverted_sub_bytes(ref data);
                add_round_key(ref data, round);
                inverted_mix_columns(ref data);

            }

            // poslednji prolaz, bez mesanja kolona, po opisu algoritma:
            inverted_shift_rows(ref data);
            inverted_sub_bytes(ref data);
            add_round_key(ref data, 0);

            // Pretvaranje rezultata nazad u string [OK]:
            buff = new byte[this.key_bytes];
            counter = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < this.key_bytes / 4; j++)
                {
                    buff[counter++] = (byte)data[i, j];
                }
            }

            return data;
        }

        #region SubBytes

        // [OK]
        protected void sub_bytes(ref byte[,] data)
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

            // Za cuvanje medju-rezultata:
            byte[,] new_mat = new byte[4, this.key_bytes / 4];

            // Za svaku kolonu:
            for(int i = 0; i < this.key_bytes / 4; i++)
            {
                new_mat[0, i] = (byte)(gfmultby02(data[0, i]) + gfmultby03(data[1, i]) + gfmultby01(data[2, i]) + gfmultby01(data[3, i]));
                new_mat[1, i] = (byte)(gfmultby01(data[0, i]) + gfmultby02(data[1, i]) + gfmultby03(data[2, i]) + gfmultby01(data[3, i]));
                new_mat[2, i] = (byte)(gfmultby01(data[0, i]) + gfmultby01(data[1, i]) + gfmultby02(data[2, i]) + gfmultby03(data[3, i]));
                new_mat[3, i] = (byte)(gfmultby03(data[0, i]) + gfmultby01(data[1, i]) + gfmultby01(data[2, i]) + gfmultby02(data[3, i]));
            
                // Mozemo i ovde da menjamo, svakako ovu kolonu vise ne diramo:
                for(int j = 0; j < 4; j++)
                    data[j, i] = new_mat[j, i];
            
            }

            // Return data [OK]
        }
        // [OK]
        protected void inverted_mix_columns(ref byte[,] data)
        {

            // Za cuvanje medju-rezultata:
            byte[,] new_mat = new byte[4, this.key_bytes / 4];

            // Za svaku kolonu:
            for (int i = 0; i < this.key_bytes / 4; i++)
            {
                new_mat[0, i] = (byte)(gfmultby0e(data[0, i]) + gfmultby0b(data[1, i]) + gfmultby0d(data[2, i]) + gfmultby09(data[3, i]));
                new_mat[1, i] = (byte)(gfmultby09(data[0, i]) + gfmultby0e(data[1, i]) + gfmultby0b(data[2, i]) + gfmultby0d(data[3, i]));
                new_mat[2, i] = (byte)(gfmultby0d(data[0, i]) + gfmultby09(data[1, i]) + gfmultby0e(data[2, i]) + gfmultby0b(data[3, i]));
                new_mat[3, i] = (byte)(gfmultby0b(data[0, i]) + gfmultby0d(data[1, i]) + gfmultby09(data[2, i]) + gfmultby0e(data[3, i]));

                // Mozemo i ovde da menjamo, svakako ovu kolonu vise ne diramo:
                for (int j = 0; j < 4; j++)
                    data[j, i] = new_mat[j, i];

            }

            // Return data [OK]
        }

        #endregion

        // [OK]
        protected void add_round_key(ref byte[,] data, int round)
        {
            // Da ne bi pravio novu promenljivu, fiksno, menja se byte na poziciji mat[3, 3];
            // A i radi za sve duzine kljuceva, tako da je to tako:

            data[3, 3] = (byte)(data[3, 3] ^ this.key_matrix[3, 3]);

        }

        // [OK]
        public void print_data(byte[,] data)
        {
            Console.WriteLine("Data matrix: ");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < this.key_bytes / 4; j++)
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
