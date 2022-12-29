using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZI_17738
{
    internal class RSA
    {
        // moze da menja korisnik preko konstruktora, a moze i ove vrednosti da koristi:
        //protected long p = 2147483647;      // large prime number
        //protected long q = 6700417;         // large prime number
        protected long p = 41;
        protected long q = 61;

        // generise se nakon poziva konstruktora:
        protected long n;
        protected long z;
        protected long private_key;
        protected long public_key;

        protected int k;

        // Dodatak za threading:
        bool[] result_flags;

        public RSA(int thread_count)
        {
            this.n = this.p * this.q;
            this.z = (this.p - 1) * (this.q - 1);
            this.result_flags = new bool[thread_count];
            for(int i = 0; i < thread_count; i++)
            {
                result_flags[i] = false;
            }

            bool is_prime = false;
            bool is_coprime = false;
            long offset = 0;

            do
            {
                // Postavljamo sve vrednosti inicijalno na false:
                this.result_flags.Select(x => x = false);
                long num = this.z - offset;
                is_prime = false;

                List<Thread> thread_list = new List<Thread>(thread_count);
                for(int i = 0; i < thread_count; i++)
                {
                    long tmp = i;
                    thread_list.Add(new Thread(() => check_is_prime((num - tmp), (int)tmp)));
                }

                thread_list.ForEach(x => x.Start());
                thread_list.ForEach(x => x.Join());

                // Provera da li smo naisli na neki prime number:
                List<long> possible_primes = new List<long>();

                for(int i = 0; i < thread_count; i++)
                {
                    if (this.result_flags[i])
                    {
                        is_prime = true;
                        possible_primes.Add(num - i);
                    }
                }

                // Koji od brojeva u opsegu od num <-> (num - offset)
                if(is_prime)
                {
                    foreach (long l in possible_primes)
                    {
                        if(l != this.z)
                        {
                            if (are_co_primes(l, this.z) == 1)
                            {
                                this.public_key = l;
                                is_coprime = true;
                                break;
                            }
                        }
                    }
                }

                offset += thread_count;
            } while (!is_coprime);

            //Console.WriteLine("Public key: " + this.public_key);

            // Generisanje Privatnog kljuca (D): 
            bool is_private_found = false;
            is_prime = false;
            offset = 0;

            do
            {
                this.result_flags.Select(x => x = false);
                long num = this.public_key + offset;
                is_prime = false;

                List<Thread> thread_list = new List<Thread>(thread_count);
                for (int i = 0; i < thread_count; i++)
                {
                    long tmp = i;
                    thread_list.Add(new Thread(() => check_is_prime((num + tmp), (int)tmp)));
                }

                thread_list.ForEach(x => x.Start());
                thread_list.ForEach(x => x.Join());

                // Probamo za sve prime number-e da li se uklapaju u formulu: 
                List<long> possible_primes = new List<long>();

                for (int i = 0; i < thread_count; i++)
                {
                    if (this.result_flags[i])
                    {
                        is_prime = true;
                        possible_primes.Add(num - i);
                    }
                }

                if(is_prime)
                {
                    foreach(long candidate in possible_primes)
                    {
                        if (!(candidate == this.public_key) && check_private(candidate))
                        {
                            this.private_key = candidate;
                            is_private_found = true;
                            break;
                        }
                    }
                }

                offset += thread_count;
            } while (!is_private_found);

            // Nisam siguran, ali koliko sam skapirao sa online RSA key generatora, velicina
            // privatnog kljuca je uvek veca on public, ne u broju bitova, nego je sam broj private > public

            // Racunanje velicine bloka:
            int counter = 0;
            int base_num = 2;
            while (base_num < this.n)
            {
                base_num = base_num << 1;
                counter++;
            }

            //counter--;
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
    }
}
