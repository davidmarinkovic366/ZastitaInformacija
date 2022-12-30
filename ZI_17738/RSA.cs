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
        protected long n = 2501;
        protected long z = 2400;
        protected long private_key = 2087;
        protected long public_key = 23;

        protected int k = 3;
        protected int chunk_size;

        // Dodatak za threading:
        bool[] result_flags;

        public RSA(int thread_count)
        {
            Console.WriteLine("Generating keys... Please be patient for a seccond!");

            this.n = this.p * this.q;
            this.z = (this.p - 1) * (this.q - 1);
            //this.result_flags = new bool[thread_count];
            //for (int i = 0; i < thread_count; i++)
            //{
            //    result_flags[i] = false;
            //}

            //bool is_prime = false;
            //bool is_coprime = false;
            //long offset = 0;

            //do
            //{
            //    // Postavljamo sve vrednosti inicijalno na false:
            //    this.result_flags.Select(x => x = false);
            //    long num = this.z - offset;
            //    is_prime = false;

            //    List<Thread> thread_list = new List<Thread>(thread_count);
            //    for (int i = 0; i < thread_count; i++)
            //    {
            //        long tmp = i;
            //        thread_list.Add(new Thread(() => check_is_prime((num - tmp), (int)tmp)));
            //    }

            //    thread_list.ForEach(x => x.Start());
            //    thread_list.ForEach(x => x.Join());

            //    // Provera da li smo naisli na neki prime number:
            //    List<long> possible_primes = new List<long>();

            //    for (int i = 0; i < thread_count; i++)
            //    {
            //        if (this.result_flags[i])
            //        {
            //            is_prime = true;
            //            possible_primes.Add(num - i);
            //        }
            //    }

            //    // Koji od brojeva u opsegu od num <-> (num - offset)
            //    if (is_prime)
            //    {
            //        foreach (long l in possible_primes)
            //        {
            //            if (l != this.z)
            //            {
            //                if (are_co_primes(l, this.z) == 1)
            //                {
            //                    this.public_key = l;
            //                    is_coprime = true;
            //                    break;
            //                }
            //            }
            //        }
            //    }

            //    offset += thread_count;
            //} while (!is_coprime);

            ////Console.WriteLine("Public key: " + this.public_key);

            //// Generisanje Privatnog kljuca (D): 
            //bool is_private_found = false;
            //is_prime = false;
            //offset = 0;

            //do
            //{
            //    this.result_flags.Select(x => x = false);
            //    long num = this.public_key + offset;
            //    is_prime = false;

            //    List<Thread> thread_list = new List<Thread>(thread_count);
            //    for (int i = 0; i < thread_count; i++)
            //    {
            //        long tmp = i;
            //        thread_list.Add(new Thread(() => check_is_prime((num + tmp), (int)tmp)));
            //    }

            //    thread_list.ForEach(x => x.Start());
            //    thread_list.ForEach(x => x.Join());

            //    // Probamo za sve prime number-e da li se uklapaju u formulu: 
            //    List<long> possible_primes = new List<long>();

            //    for (int i = 0; i < thread_count; i++)
            //    {
            //        if (this.result_flags[i])
            //        {
            //            is_prime = true;
            //            possible_primes.Add(num - i);
            //        }
            //    }

            //    if (is_prime)
            //    {
            //        foreach (long candidate in possible_primes)
            //        {
            //            if (!(candidate == this.public_key) && check_private(candidate))
            //            {
            //                this.private_key = candidate;
            //                is_private_found = true;
            //                break;
            //            }
            //        }
            //    }

            //    offset += thread_count;
            //} while (!is_private_found);

            //// Nisam siguran, ali koliko sam skapirao sa online RSA key generatora, velicina
            //// privatnog kljuca je uvek veca on public, ne u broju bitova, nego je sam broj private > public

            // Racunanje velicine bloka:
            int counter = 0;
            int base_num = 2;
            while (base_num < this.n)
            {
                base_num = base_num << 1;
                counter++;
            }

            counter--;
            this.k = counter;
            Console.WriteLine("N: \t" + this.n);
            Console.WriteLine("Z: \t" + this.z);
            Console.WriteLine("K: \t" + this.k);
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

        public long are_co_primes(long first, long seccond)
        {
            if (first == 0 || seccond == 0)
                return 0;
            if (first == seccond)
                return first;
            if (first > seccond)
                return are_co_primes(first - seccond, seccond);

            return are_co_primes(first, seccond - first);
        }

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
