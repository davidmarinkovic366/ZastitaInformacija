using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ZI_17738
{
    internal class RSA
    {

        protected long p = 41;
        protected long q = 61;

        // generise se nakon poziva konstruktora:
        protected long n;
        protected long z;
        protected long private_key;
        protected long public_key;

        protected int k;
        protected int chunk_size;

        // Dodatak za threading:
        bool[] result_flags;

        public RSA(int thread_count)
        {
            Console.WriteLine("Generating keys... Please be patient for a seccond!");

            this.n = this.p * this.q;
            this.z = (this.p - 1) * (this.q - 1);

            this.result_flags = new bool[thread_count];
            // FIXME: suvisno, svakako se prilikom svakog prolaska kroz do-while izvrsava restartovanje
            // flegova;
            //this.result_flags.Select(x => x = false);

            bool is_coprime = false;
            long offset = 0;
            int start = 2;

            // Pronalazenje vrednosti E:
            // E sad, malo sam se snasao sa pravilima, jer vazi da su dva uzastopna 
            // integera uvek uzajamno-prosti, tako da uz pravilo da 1 < e < fi(n),
            // dobijamo da vrednost E uvek moze da bude fi(n) - 1, cime zadovoljavamo
            // oba pravila, svestan sam da pravi algoritam ne radi ovako, ali dosta brze izvrsava
            // algoritam ako ne moramo da proveravamo svaki put za svaki broj da li je uzajamno-prost
            // sa fi(n)
            // ref: https://simple.wikipedia.org/wiki/Coprime
            // pravilo 1.
            // moze se proveriti ovim alatom za bilo koju kombinaciju p i q, odnosno, fi(n)
            // ref: https://www.mathsisfun.com/numbers/coprime-calculator.html

            this.public_key = this.z - 1;

            // Pronalazenje vrednosti D:
            int k = 0;
            bool found = false;
            do
            {
                Console.WriteLine("Testing k: ", k);
                if ((1 + k * this.z) % this.public_key == 0)
                {
                    this.private_key = ((1 + k * this.z) / this.public_key);
                    found = true;
                }

                k++;
            } while (!found || k < this.public_key);

            Console.WriteLine("N: \t" + this.n);
            Console.WriteLine("Z: \t" + this.z);
            //Console.WriteLine("K: \t" + this.k);
            Console.WriteLine("Pr:\t" + this.private_key);
            Console.WriteLine("Pu:\t" + this.public_key);

        }
        public RSA(long p, long q)
        {
            this.p = p;
            this.q = q;
        }

        public void check_is_prime(long number, int pos)
        {
            //Console.WriteLine("Thread: " + pos + " checking number: " + number);
            if (number == 1)
            {
                this.result_flags[pos] = false;
                return;
            }
            if (number == 2)
            {
                this.result_flags[pos] = true;
                return;
            }

            var limit = Math.Ceiling(Math.Sqrt(number)); //hoisting the loop limit

            for (long i = 2; i <= limit; ++i)
                if (number % i == 0)
                {
                    this.result_flags[pos] = false;
                    return;
                }

            this.result_flags[pos] = true;
            return;
        }

        public bool check_private(long num)
        {
            //Console.WriteLine("Checking prime number for Private key: " + num);
            return ((num * public_key) % z == 1);
        }

        //public void are_co_primes(long first, long seccond, ref bool flag)
        //{
            
        //}

        public string encrypt(string data)
        {
            // Convert string to int: [OK]
            byte[] encoded = Encoding.ASCII.GetBytes(data);
            string encoded_data = "";
            string encrypted_data = "";

            // Dodavanje ne-vazecih nula, kako bi svaki karakter bio duzine 3 karaktera:
            foreach (byte b in encoded)
            {
                string tmp = b.ToString();
                tmp = string.Concat(Enumerable.Repeat('0', 3 - tmp.Length)) + tmp;
                Console.WriteLine(tmp);
                encoded_data += tmp;
            }

            Console.WriteLine("Data:           " + encoded_data);


            // Encrypt []
            // E sad, koliko mogu da budu veliki brojevi? 
            // Kljuc je velicine 11b (za date ulazne parametre),
            // Sa 11b, najveci broj koji mozemo da predstavimo je:
            // 0 - 4095

            // Generisemo broj velicine 2^k, kako bi ga preveli na decimalni:
            int base_num = 0;
            int i = 1;
            while (i <= this.k)
            {
                base_num = base_num << 1;
                base_num += 1;
                i++;
            }

            string base_num_str = base_num.ToString();
            int tmp_chunk_size = base_num_str.Length;
            this.chunk_size = tmp_chunk_size;

            // razdvajanje stringa po chunk_size delove [OK]:
            do
            {
                // Za slucaj da broj cifara nije deljiv sa chunk_size, da ne bi dobili IndexOutOfRange Exception:
                // Mora 3, zato sto su ascii karakteri od 0 do 255, da bi imali formalni zapis svakog karaktera
                if (encoded_data.Length < tmp_chunk_size)
                    tmp_chunk_size = encoded_data.Length;

                string sub = encoded_data.Substring(0, tmp_chunk_size);
                encoded_data = encoded_data.Remove(0, tmp_chunk_size);
                int sub_int = Int32.Parse(sub);

                Console.Write("Encrypting: " + sub);
                BigInteger C = (BigInteger)Math.Pow(sub_int, (int)this.public_key);
                C = (BigInteger)(C % this.n);
                Console.Write("\tEncrypted: " + C);

                BigInteger M = (BigInteger)Math.Pow((long)C, (int)this.private_key);
                M = (BigInteger)(M % this.n);
                Console.WriteLine("\tDecrypted: " + M);

                sub = C.ToString();
                sub = string.Concat(Enumerable.Repeat('0', tmp_chunk_size - sub.Length)) + sub;

                //Console.WriteLine("\t-> " + sub);
                encrypted_data += sub;

            } while (encoded_data.Length > 0);

            Console.WriteLine("Encrypted data: " + encrypted_data);

            return encrypted_data;
        }

        public string decrypt(string data)
        {

            // split into chunks:
            Console.WriteLine("Data:           " + data);
            int tmp_chunk_size = this.chunk_size;
            string decrypted_data = "";

            do
            {
                // get chunk:
                string chunk_str = data.Substring(0, tmp_chunk_size);
                data = data.Remove(0, tmp_chunk_size);

                int chunk_int = Int32.Parse(chunk_str);
                BigInteger M = (BigInteger)Math.Pow(chunk_int, (int)this.private_key);
                M = (BigInteger)(M % this.n);

                chunk_str = M.ToString();

                // Ponovo dodavanje nevazecih nula sa leve strane, kako bi postigli da je svaki ASCII karakter duzine 3 broja:
                chunk_str = string.Concat(Enumerable.Repeat('0', tmp_chunk_size - chunk_str.Length)) + chunk_str;
                Console.WriteLine("chunk str: " + chunk_str);

                decrypted_data += chunk_str;



            } while (data.Length > 0);

            Console.WriteLine("Decrypted data: " + decrypted_data);

            // Transforming data to string: 



            return " ";
        }
    }
}
