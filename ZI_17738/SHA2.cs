using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ZI_17738
{
    internal class SHA2
    {
        // 32b blokovi:
        protected uint h0, h1, h2, h3, h4, h5, h6, h7;
        protected uint[] keys;

        public SHA2()
        {
            this.h0 = 0x6a09e667;
            this.h1 = 0xbb67ae85;
            this.h2 = 0x3c6ef372;
            this.h3 = 0xa54ff53a;
            this.h4 = 0x510e527f;
            this.h5 = 0x9b05688c;
            this.h6 = 0x1f83d9ab;
            this.h7 = 0x5be0cd19;

            this.keys = new uint[64] {
                0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
                0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
                0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
                0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
                0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
                0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
                0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
                0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
            };
        }

        public string encrypt(string data)
        {
            byte[] transformed = preprocessing(Encoding.ASCII.GetBytes(data));
            uint[] table = new uint[64];

            for(int i = 0; i < transformed.Length / 64; i++)
            {
                uint[] block = split_block(transformed, (i * 64));
                table = init_table(block);
                process_block(table);
            }

            // Pretvaranje podataka u string:
            //byte[] list = new byte[256];
            byte[] h00 = BitConverter.GetBytes(this.h0);
            byte[] h11 = BitConverter.GetBytes(this.h1);
            byte[] h22 = BitConverter.GetBytes(this.h2);
            byte[] h33 = BitConverter.GetBytes(this.h3);
            byte[] h44 = BitConverter.GetBytes(this.h4);
            byte[] h55 = BitConverter.GetBytes(this.h5);
            byte[] h66 = BitConverter.GetBytes(this.h6);
            byte[] h77 = BitConverter.GetBytes(this.h7);

            List<byte> lista = h00.Concat(h11).Concat(h22).Concat(h33).Concat(h44).Concat(h55).Concat(h66).Concat(h77).ToList();
            string result_str = BitConverter.ToString(lista.ToArray()).Replace("-", String.Empty).ToLower();

            Console.WriteLine("Result: " + result_str);

            return result_str;
        }

        protected byte[] preprocessing(byte[] initial_message)
        {
            // E sad, posto je duzina ulaznog stringa uvek umnozak 8, jer svaki karakter u ASCII
            // predstavljamo sa 8b, onda mozemo da racunamo da ce ulazni string uvek da bude manji od 448b,
            // odnosno, max duzina ulaznog bloka bi bila: 440b (kako bi mogli da dodamo jedinicu i 7 nula)
            // da se radi o binarnim podacima, onda moze da se desi da je ulaz 447b, mada svakako kodom pokrivam
            // i taj slucaj:

            // Cuvamo duzinu originalne poruke, mnozimo sa 8 jer se odnosu na duzinu u bitovima:
            uint original_size = (uint)initial_message.Length * 8;

            // Koristim listu zbog dodavanja, nista brze nije ako rucno pravim nove nizove i
            // alociram novu memoriju prilikom svakog prolaska:

            List<byte> data = new List<byte>(initial_message);
            uint initial = 1;
            // Minimalno sto mozemo da dodamo jeste 1B, odnosno 1 jedinica i 7 nula, tako da je 
            // samo prvim dodavanjem vidimo jedinicu, svaki sledeci put sa (byte) odsecemo sve iznad 8-mog
            // bita tako da ispada kao da dodajemo sve nule:
            do
            {
                initial = initial << 7;
                data.Add((byte)initial);
            } while ((data.Count * 8) % 512 < 480);

            // E sad, postoji problem sa generalno microsoft-om i njegovom proverom da li se podaci
            // cuvaju u Little-Endian ili u Big-Endian zapisu, tako da u zavisnosti od toga na kom
            // racunaru se pokrece, mozda je nekad potrebno okretanje niza, kao sto je slucaj kod mene.

            byte[] length_arr = BitConverter.GetBytes(original_size).Reverse().ToArray();

            foreach (byte b in length_arr)
                data.Add(b);

            return data.ToArray();
        }

        protected uint[] split_block(byte[] data, int start = 0)
        {
            uint[] result = new uint[16];
            for(int i = 0; i < 16; i++)
            {
                // Nzm zasto, ali moj komp uporno radi sa big endian podacima, a za algoritam
                // su potrebni little endian podaci, tako da moram ovako:
                result[i] = BinaryPrimitives.ReverseEndianness(BitConverter.ToUInt32(data, (start + (i * 4))));
            }

            return result;
        }


        #region Processing
        protected uint S0(uint num) 
        {
            uint first = BitOperations.RotateRight(num, 2);
            uint seccond = BitOperations.RotateRight(num, 13);
            uint third = BitOperations.RotateRight(num, 22);

            return (first ^ seccond ^ third);
        }
        protected uint S1(uint num)
        {
            uint first = BitOperations.RotateRight(num, 6);
            uint seccond = BitOperations.RotateRight(num, 11);
            uint third = BitOperations.RotateRight(num, 25);

            return (first ^ seccond ^ third);
        }
        protected uint Ma(uint first, uint seccond, uint third)
        {
            return ((first & seccond) ^ (first & third) ^ (seccond & third));
        }

        protected uint Ch(uint first, uint seccond, uint third)
        {
            return ((first & seccond) ^ ((~first) & third));
        }

        // kao argument saljemo uint[64] tabelu W koju smo kreirali sa init_table
        protected void process_block(uint[] data)
        {
            uint[] table = new uint[8]
            {
                h0, h1, h2, h3, h4, h5, h6, h7
            };

            for(int i = 0; i < 64; i++)
            {
                uint s0 = S0(table[0]); // A
                uint s1 = S1(table[4]); // E

                uint ma = Ma(table[0], table[1], table[2]); // A, B, C
                uint ch = Ch(table[4], table[5], table[6]); // E, F, G

                uint t1 = table[7] + s1 + ch + this.keys[i] + data[i];
                uint t2 = s0 + ma;

                table[7] = table[6];
                table[6] = table[5];
                table[5] = table[4];
                table[4] = table[3] + t1;
                table[3] = table[2];
                table[2] = table[1];
                table[1] = table[0];
                table[0] = t1 + t2;
            }

            // Nakon 64 runde, rezultate prethodnog algoritma dodajemo na pocetno inicijalizovane 
            // vektore
            this.h0 = this.h0 + table[0];
            this.h1 = this.h1 + table[1];
            this.h2 = this.h2 + table[2];
            this.h3 = this.h3 + table[3];
            this.h4 = this.h4 + table[4];
            this.h5 = this.h5 + table[5];
            this.h6 = this.h6 + table[6];
            this.h7 = this.h7 + table[7];

            // FIXME return
            //return table;
        }

        #endregion

        #region Table init
        protected uint Sum0(uint num)
        {
            uint first_rotation = BitOperations.RotateRight(num, 7);
            uint seccond_rotation = BitOperations.RotateRight(num, 18);
            uint shift_result = num >> 3;

            return (first_rotation ^ seccond_rotation ^ shift_result);
        }
        protected uint Sum1(uint num)
        {
            uint first_rotation = BitOperations.RotateRight(num, 17);
            uint seccond_rotation = BitOperations.RotateRight(num, 19);
            uint shift_result = num >> 10;

            return (first_rotation ^ seccond_rotation ^ shift_result);
        }
        protected uint[] init_table(uint[] data) 
        {
            uint[] table = new uint[64];
            
            // from 0 - 8
            for(int i = 0; i < 16; i++)
                table[i] = data[i];

            //s0 s1 operacije..
            for(int i = 16; i < 64; i++)
            {
                table[i] = (uint)(Sum1(table[i - 2]) + table[i - 7] + Sum0(table[i - 15]) + table[i - 16]);
            }

            return table;
        }

        #endregion  


    }
}
