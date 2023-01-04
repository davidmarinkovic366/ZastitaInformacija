using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZI_17738
{
    internal class CFB
    {
        protected byte[] round_key;
        protected byte[] aes_result;
        protected byte[] aes_input;
        protected byte[] result;

        protected int round_counter;
        protected int data_counter;

        // encrypt blok u CFB algoritmu je kod mene 128b AES algoritam:
        // AES se u sustini ovde koristi samo za konstantno generisanje kljuca kojim se radi XOR?
        protected AES aes;

        public CFB() { }
        public CFB(byte[] aes_key, byte[] init_vec)
        {
            this.round_key = init_vec;
            this.aes = new AES((128 / 8), aes_key);
            this.data_counter = 0;
        }

        public byte[] encrypt(byte[] data)
        {
            byte[] result = new byte[data.Length];
            int counter = 0;
            // Loop:
            for (int i = 0; i < data.Length / 8; i++)
            {
                byte[] block = get_data_block(data, i);

                byte[] aes_result = aes.encrypt(this.round_key, "F:\\zi\\encrypt_result.bin");
                byte[] encrypted_data = xor_aes_result(aes_result, block);
                gen_next_round_key(ref this.round_key, encrypted_data);

                foreach (byte b in encrypted_data)
                {
                    result[counter++] = (byte)b;
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }

            // FIXME: Return [X]
            return result;
        }

        public byte[] decrypt(byte[] data)
        {
            byte[] result = new byte[data.Length];
            int counter = 0;
            // Loop:
            for(int i = 0; i < data.Length / 8; i++)
            {
                byte[] cipher_block = get_data_block(data, i);
                byte[] aes_result = aes.encrypt(this.round_key, "F:\\zi\\encrypt_result.bin");
                byte[] decrypted_data = xor_aes_result(cipher_block, aes_result);
                gen_next_round_key(ref this.round_key, cipher_block);

                foreach (byte b in decrypted_data)
                {
                    result[counter++] = b;
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }

            string decrypted_string = Encoding.ASCII.GetString(result);
            Console.WriteLine("CFB decrypted data: " + decrypted_string);

            return data;
        }

        // xor operacija nad prvim 8B rezultata AES algoritma i 8B teksta koji enkriptujemo
        // [OK]
        protected byte[] xor_aes_result(byte[] aes_data, byte[] plaintext)
        {
            byte[] result = new byte[8];
            for(int i = 0; i < 8; i++)
            {
                Console.Write(aes_data[i] + " xor " + plaintext[i] + ": ");
                result[i] = (byte)(aes_data[i] ^ plaintext[i]);
                Console.WriteLine(result[i]);
            }

            return result;
        }

        // da bi metode za enkripciju/dekripciju izgledale malo uredjenije, logika za razdvajanje plaintext-a na blokove je ovde razdvojena:
        // [OK]
        protected byte[] get_data_block(byte[] data, int step)
        {
            // izdvajamo 8B/64b podataka iz plaintext-a:
            byte[] data_chunk = new byte[8];
            int counter = 0;
            for (int i = (step * 8); i < ((step * 8) + 8); i++)
                data_chunk[counter++] = data[i];

            return data_chunk;
        }

        protected void gen_next_round_key(ref byte[] prev_key, byte[] aes_result)
        {
            for(int i = 4; i < 8; i++)
            {
                prev_key[i - 4] = prev_key[i];
                prev_key[i] = aes_result[i - 4];
            }
        }

    }
}
