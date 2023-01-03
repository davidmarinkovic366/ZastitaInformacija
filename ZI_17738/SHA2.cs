using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            for(int i = 0; i < transformed.Length / 64; i++)
            {
                uint[] block = split_block(transformed, (i * 64));
            }

            return " ";
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

            data.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            return data.ToArray();
        }

        protected uint[] split_block(byte[] data, int start = 0)
        {
            uint[] result = new uint[8];
            for(int i = 0; i < 8; i++)
            {
                // Nzm zasto, ali moj komp uporno radi sa big endian podacima, a za algoritam
                // su potrebni little endian podaci, tako da moram
                result[i] = BinaryPrimitives.ReverseEndianness(BitConverter.ToUInt32(data, (start + (i * 8))));
                Console.WriteLine(result[i]);
            }

            return result;
        }

        //protected uint Ch()
        //{
        //    return (uint)(this.h4 ^ this.h5 ^ this.h6);
        //}
        //protected uint S1()
        //{
        //    return (uint)(this.)
        //}
        //protected uint Ma()
        //{

        //}

        //protected uint S0()
        //{

        //}




    }
}
