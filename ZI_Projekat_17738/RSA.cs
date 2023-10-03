using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ZI_Projekat_17738
{
    internal class RSA
    {

        protected int p;
        protected int q;

        // generise se nakon poziva konstruktora:
        protected int n;
        protected int fi;
        protected int e;
        protected int d;

        public int k;


        public RSA()
        {
        }
        public RSA(int p, int q)
        {
            this.p = p;
            this.q = q;


            this.n = p * q;
            this.fi = (p - 1) * (q - 1);
            
            // Generisanje dela javnog kljuca:
            this.e = 1;
            if(e == 1 || calculate_e(fi, e) > 1)
            {
                if (e == 1)
                    this.e = 3;
                while(calculate_e(fi, e) > 1)
                {
                    this.e++;
                }
            }

            // Generisanje dela privatnog kljuca:
            this.d = 1;
            while((this.d * this.e) % this.fi != 1)
            {
                this.d++;
            }

            //this.e = 3;
            //this.d = 3;
            //this.k = (int)Math.Log2(this.n);

            Console.WriteLine("Generated values: ");

            Console.WriteLine("P: \t", this.p);
            Console.WriteLine("Q: \t", this.q);
            Console.WriteLine("N: \t", this.n);
            Console.WriteLine("Fi: \t", this.fi);
            Console.WriteLine("E: \t", this.e);
            Console.WriteLine("D: \t", this.d);
            //Console.WriteLine("K: \t", this.k);

        }

        public int calculate_e(int fi, int tmp_e)
        {
            if ((fi % tmp_e) == 0)
            {
                return tmp_e;
            }
            else
            {
                fi -= tmp_e;
                if (fi > tmp_e)
                    return this.calculate_e(fi, tmp_e);
                else
                    return this.calculate_e(tmp_e, fi);
            }
        }

        public uint[] encrypt(byte[] data)
        {
            //int[] result = new int[data.Length];

            //byte[] data = transform_data(dataa);

            List<uint> result = new List<uint>();
            foreach(byte b in data)
            {
                uint chunk = (uint)(b);
                for (uint i = 1; i < this.e; i++)
                    chunk = (chunk * b) % ((uint)this.n);

                //chunk = (uint)(Math.Pow(chunk, this.e) % this.n);
                result.Add(chunk);
            }

            return result.ToArray();
        }

        public byte[] decrypt(uint[] data)
        {
            List<byte> result = new List<byte>();
            foreach(uint i in data)
            {
                //BigInteger chunk_res = (BigInteger)(Math.Pow(i, this.d));
                //chunk_res = chunk_res % this.n;
                uint tmp = i;
                for (uint j = 1; j < this.d; j++)
                    tmp = (tmp * i) % ((uint)this.n);

                result.Add(((byte)tmp));
            }

            return result.ToArray();
        }

        public byte[] transform_data(byte[] data)
        {
            string long_data = "";
            foreach (byte b in data)
            {
                string tmp_chunk = ((int)(b)).ToString();
                // ako je char = '3', a k = 3, onda moramo da pretvorimo u: '003';
                for (int i = 0; i < this.k - tmp_chunk.Length; i++)
                    tmp_chunk = "0" + tmp_chunk;
                
                long_data += tmp_chunk;
            }

            //List<string> split_data = new List<string>();

            // Razdvajamo blokove na odgovarajucu velicinu:
            List<byte> split_data = new List<byte>();
            for(int i = 0; i < (long_data.Length - this.k); i += this.k)
            {
                //split_data.Add(long_data.Substring(i, this.k));
                split_data.Add((byte)Int32.Parse(long_data.Substring(i, this.k)));
            }

            return split_data.ToArray();
        }

        //public void check_is_prime(long number, int pos)
        //{
        //    //Console.WriteLine("Thread: " + pos + " checking number: " + number);
        //    if (number == 1)
        //    {
        //        this.result_flags[pos] = false;
        //        return;
        //    }
        //    if (number == 2)
        //    {
        //        this.result_flags[pos] = true;
        //        return;
        //    }

        //    var limit = Math.Ceiling(Math.Sqrt(number)); //hoisting the loop limit

        //    for (long i = 2; i <= limit; ++i)
        //        if (number % i == 0)
        //        {
        //            this.result_flags[pos] = false;
        //            return;
        //        }

        //    this.result_flags[pos] = true;
        //    return;
        //}

        //public bool check_private(long num)
        //{
        //    //Console.WriteLine("Checking prime number for Private key: " + num);
        //    return ((num * public_key) % z == 1);
        //}

        //public long are_co_primes(long first, long seccond)
        //{
        //    if (first == 0 || seccond == 0)
        //        return 0;
        //    if (first == seccond)
        //        return first;
        //    if (first > seccond)
        //        return are_co_primes(first - seccond, seccond);

        //    return are_co_primes(first, seccond - first);
        //}

        //public string encrypt(string data)
        //{
        //    // Convert string to int: [OK]
        //    byte[] encoded = Encoding.ASCII.GetBytes(data);
        //    string encoded_data = "";
        //    string encrypted_data = "";

        //    // Dodavanje ne-vazecih nula, kako bi svaki karakter bio duzine 3 karaktera:
        //    foreach (byte b in encoded)
        //    {
        //        string tmp = b.ToString();
        //        tmp = string.Concat(Enumerable.Repeat('0', 3 - tmp.Length)) + tmp;
        //        Console.WriteLine(tmp);
        //        encoded_data += tmp;
        //    }

        //    Console.WriteLine("Data:           " + encoded_data);


        //    // Encrypt []
        //    // E sad, koliko mogu da budu veliki brojevi? 
        //    // Kljuc je velicine 11b (za date ulazne parametre),
        //    // Sa 11b, najveci broj koji mozemo da predstavimo je:
        //    // 0 - 4095

        //    // Generisemo broj velicine 2^k, kako bi ga preveli na decimalni:
        //    int base_num = 0;
        //    int i = 1;
        //    while (i <= this.k)
        //    {
        //        base_num = base_num << 1;
        //        base_num += 1;
        //        i++;
        //    }

        //    string base_num_str = base_num.ToString();
        //    int tmp_chunk_size = base_num_str.Length;
        //    this.chunk_size = tmp_chunk_size;

        //    // razdvajanje stringa po chunk_size delove [OK]:
        //    do
        //    {
        //        // Za slucaj da broj cifara nije deljiv sa chunk_size, da ne bi dobili IndexOutOfRange Exception:
        //        // Mora 3, zato sto su ascii karakteri od 0 do 255, da bi imali formalni zapis svakog karaktera
        //        if (encoded_data.Length < tmp_chunk_size)
        //            tmp_chunk_size = encoded_data.Length;

        //        string sub = encoded_data.Substring(0, tmp_chunk_size);
        //        encoded_data = encoded_data.Remove(0, tmp_chunk_size);
        //        int sub_int = Int32.Parse(sub);

        //        Console.Write("Encrypting: " + sub);
        //        BigInteger C = (BigInteger)Math.Pow(sub_int, (int)this.public_key);
        //        C = (BigInteger)(C % this.n);
        //        Console.Write("\tEncrypted: " + C);

        //        BigInteger M = (BigInteger)Math.Pow((long)C, (int)this.private_key);
        //        M = (BigInteger)(M % this.n);
        //        Console.WriteLine("\tDecrypted: " + M);

        //        sub = C.ToString();
        //        sub = string.Concat(Enumerable.Repeat('0', tmp_chunk_size - sub.Length)) + sub;

        //        //Console.WriteLine("\t-> " + sub);
        //        encrypted_data += sub;

        //    } while (encoded_data.Length > 0);

        //    Console.WriteLine("Encrypted data: " + encrypted_data);

        //    return encrypted_data;
        //}

        //public string decrypt(string data)
        //{

        //    // split into chunks:
        //    Console.WriteLine("Data:           " + data);
        //    int tmp_chunk_size = this.chunk_size;
        //    string decrypted_data = "";

        //    do
        //    {
        //        // get chunk:
        //        string chunk_str = data.Substring(0, tmp_chunk_size);
        //        data = data.Remove(0, tmp_chunk_size);

        //        int chunk_int = Int32.Parse(chunk_str);
        //        BigInteger M = (BigInteger)Math.Pow(chunk_int, (int)this.private_key);
        //        M = (BigInteger)(M % this.n);

        //        chunk_str = M.ToString();

        //        // Ponovo dodavanje nevazecih nula sa leve strane, kako bi postigli da je svaki ASCII karakter duzine 3 broja:
        //        chunk_str = string.Concat(Enumerable.Repeat('0', tmp_chunk_size - chunk_str.Length)) + chunk_str;
        //        Console.WriteLine("chunk str: " + chunk_str);

        //        decrypted_data += chunk_str;



        //    } while (data.Length > 0);

        //    Console.WriteLine("Decrypted data: " + decrypted_data);

        //    // Transforming data to string: 



        //    return " ";
        //}
    }
}
