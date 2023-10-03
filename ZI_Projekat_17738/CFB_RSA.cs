using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZI_Projekat_17738
{
    internal class CFB_RSA
    {
        protected byte[] round_vector;
        protected RSA rsa;

        public CFB_RSA() { }
        public CFB_RSA(byte[] init_vec, int p, int q)
        {
            this.round_vector = init_vec;
            this.rsa = new RSA(p, q);
        }
        
        public byte[] encrypt(byte[] plaintext)
        {
            // blok duzine 8 * 8b = 64b / 8B
            int block_count = plaintext.Length / 8;
            byte[] result = new byte[plaintext.Length];

            for(int i = 0; i < block_count; i++)
            {
                byte[] plaintext_block = new byte[8];
                Array.Copy(plaintext, i * 8, plaintext_block, 0, 8);

                uint[] res_uint = rsa.encrypt(this.round_vector);
                byte[] enc_byte_arr = res_uint.Select(x => (byte)(x)).ToArray();

                byte[] cypher_block = new byte[8];
                for (int j = 0; j < 8; j++)
                    cypher_block[j] = (byte)(enc_byte_arr[j] ^ plaintext_block[j]);
                //result[i * 8 + j] = (byte)(enc_byte_arr[j] ^ this.round_vector[j]);

                Array.Copy(cypher_block, 0, result, i * 8, 8);
                next_round_vector(ref round_vector, cypher_block);
            }

            // ako je ostao blok duzine manje od 8?
            int last_block_size = plaintext.Length - (int)(plaintext.Length / 8) * 8;
            if(last_block_size > 0)
            {
                byte[] plaintext_block = new byte[last_block_size];
                
                // Generisanje kljuca za trenutnu rundu:
                uint[] res_uint = rsa.encrypt(this.round_vector);
                byte[] enc_byte_arr = res_uint.Select(x => (byte)(x)).ToArray();

                // Enkripcia plaintext-a:
                byte[] cypher_block = new byte[last_block_size];
                for (int i = 0; i < last_block_size; i++)
                    cypher_block[i] = (byte)(plaintext_block[i] ^ enc_byte_arr[i]);

                Array.Copy(cypher_block, 0, result, plaintext.Length - last_block_size, last_block_size);
                // nema potrebe za generisanjem vektora za sledecu rundu, nema vise stvari za enkripciju;
            }

            // FIXME: return encrypted data;
            return result;
        }

        public byte[] decrypt(byte[] cypher_text)
        {
            int block_count = cypher_text.Length / 8;
            byte[] result = new byte[cypher_text.Length];

            for(int i = 0; i < block_count; i++)
            {
                byte[] cypher_block = new byte[8];
                Array.Copy(cypher_text, i * 8, cypher_block, 0, 8);

                byte[] rsa_res = rsa.encrypt(this.round_vector).Select(x => (byte)(x)).ToArray();

                byte[] plaintext_block = new byte[8];
                for (int j = 0; j < 8; j++)
                    plaintext_block[j] = (byte)(rsa_res[j] ^ cypher_block[j]);


                Array.Copy(plaintext_block, 0, result, i * 8, 8);
                next_round_vector(ref round_vector, cypher_block);
            }

            // ako je ostao blok duzine manje od 8?
            int last_block_size = cypher_text.Length - (int)(cypher_text.Length / 8) * 8;
            if (last_block_size > 0)
            {
                byte[] cypher_block = new byte[last_block_size];

                // Generisanje kljuca za trenutnu rundu:
                byte[] enc_byte_arr = rsa.encrypt(this.round_vector).Select(x => (byte)(x)).ToArray();
 
                // Enkripcia plaintext-a:
                byte[] plaintext_block = new byte[last_block_size];
                for (int i = 0; i < last_block_size; i++)
                    plaintext_block[i] = (byte)(cypher_block[i] ^ enc_byte_arr[i]);

                Array.Copy(plaintext_block, 0, result, cypher_text.Length - last_block_size, last_block_size);
                // nema potrebe za generisanjem vektora za sledecu rundu, nema vise stvari za enkripciju;
            }

            // FIXME: return decrypted data;
            return result;
        }


        // Generise vektor za sledecu rundu:
        public void next_round_vector(ref byte[] last_round_vector, byte[] new_vector)
        {
            last_round_vector = new_vector;
        }


    }
}
