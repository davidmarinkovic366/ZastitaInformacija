using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ZI_17738
{
    internal class A5_1
    {
        // X, Y i Z shift registri, inicijalno, svi su popunjeni nulama:
        protected BitArray x_reg = new BitArray(19, false);
        protected BitArray y_reg = new BitArray(22, false);
        protected BitArray z_reg = new BitArray(23, false);

        public A5_1()
        {
        }
        public A5_1(string key)
        {

            // Pretvaranje kljuca u niz tipa string koji predstavlja binarni zapis kljuca:
            string key_transformed = string.Join("", Encoding.ASCII.GetBytes(key).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
            //Console.WriteLine(key_transformed);

            // Okretanje kljuca naopako, prirodnije je da brojanje krene od 0 sa krajnje desne strane string:
            char[] charArray = key_transformed.ToCharArray();
            Array.Reverse(charArray);
            key_transformed = new string(charArray);

            #region Shift_register_initialisation

            // U registu X, inicijalno se nalaze nizih 19 bitova kljuca:
            int offset = 0;
            for (int i = 0; i < 19; i++)
            {
                if (key_transformed[i] == '1')
                    this.x_reg.Set(i, true);
            }

            // U registru Y, inicijalno se nalaze bitovi od indeksa 19 do 40, gledajuci od LSB:
            offset = 19;
            for (int i = 0; i < 22; i++)
            {
                if (key_transformed[offset + i] == '1')
                    this.y_reg.Set(i, true);
            }

            // U registru Z, inicijalno se nalaze najvisih 23 bita kljuca, odnosno od indeksa 41 do 63:
            offset += 22;
            for (int i = 0; i < 23; i++)
            {
                if (key_transformed[offset + i] == '1')
                    this.z_reg.Set(i, true);
            }

            #endregion

            // FIXME: Stampanje, radi provere kako su popunjeni registri:
            //Console.WriteLine("Initial register state: \n");

            //Console.Write("X reg: ");
            //printRegister(this.x_reg);

            //Console.Write("Y reg: ");
            //printRegister(this.y_reg);

            //Console.Write("Z reg: ");
            //printRegister(this.z_reg);

            //Console.WriteLine("=============================================\n\n\n");

        }
        public bool maj(params bool[] args)
        {
            int count_true = 0;
            int count_false = 0;

            foreach (bool b in args)
            {
                if (b)
                    count_true++;
                else
                    count_false++;
            }

            if (count_true > count_false)
                return true;
            else
                return false;

        }
        
        // Metoda sluzi samo za debagiranje i prikaz promene stanja registra izmedju dva koraka: 
        public void printRegister(BitArray register)
        {
            int i = 0;
            string data = "";
            while (i < register.Length)
            {
                if (register[i] == true)
                    data = "1 " + data;
                else
                    data = "0 " + data;
                i++;
            }

            Console.WriteLine(data);
        }

        // Preglednije je ovako nego da svaki put navodimo indekse pozicije u registru:
        public bool generate_keystream()
        {
            return shift_register(maj(x_reg.Get(8), y_reg.Get(10), z_reg.Get(10)));
        }

        public bool shift_register(bool val)
        {
            if (this.x_reg.Get(8) == val)
            {
                bool t = x_reg.Get(13) ^ x_reg.Get(16) ^ x_reg.Get(17) ^ x_reg.Get(18);
                this.x_reg.LeftShift(1);
                this.x_reg.Set(0, t);
            }

            if (this.y_reg.Get(10) == val)
            {
                bool t = y_reg.Get(20) ^ y_reg.Get(21);
                this.y_reg.LeftShift(1);
                this.y_reg.Set(0, t);
            }

            if (this.z_reg.Get(10) == val)
            {
                bool t = z_reg.Get(7) ^ z_reg.Get(20) ^ z_reg.Get(21) ^ z_reg.Get(22);
                this.z_reg.LeftShift(1);
                this.z_reg.Set(0, t);
            }

            // Vracamo bit koji predstavlja deo kljuca:
            return (x_reg.Get(x_reg.Length - 1) ^ y_reg.Get(y_reg.Length - 1) ^ z_reg.Get(z_reg.Length - 1));
        }

        // Mora da vrati niz bajtova zato sto ako vratimo string, desi se da zbog karaktera
        // potpuno promeni odredjene karaktere koji nisu standartni u ASCII tabeli (zbog opsega vrednost),
        // pa se desi da broj '1' pretvori u specijalni karakter srce...
        public byte[] encrypt(string data)
        {
            // Razbijanje podataka na byte vrednosti [OK]:
            BitArray bit_arr = new BitArray(Encoding.ASCII.GetBytes(data));
            BitArray result = new BitArray(bit_arr.Length, false);  // Default su svi 0!

            // Petlja za kodiranje podataka: [OK]
            for(int i = 0; i < bit_arr.Length; i++)
            {
                bool key_bit = generate_keystream();
                result.Set(i, bit_arr[i] ^ key_bit);
            }

            byte[] result_arr = new byte[(result.Length - 1) / 8 + 1];
            result.CopyTo(result_arr, 0);

            // Vracanje rezultata: [OK]
            string result_str = Encoding.ASCII.GetString(result_arr);
            Console.WriteLine("Encrypted data: " + result_str);
            return result_arr;
        }


        // Uzimamo niz byte-ova koji smo prethodno dobili kodiranjem, i pretvara u string podatak
        public string decrypt(byte[] data)
        {
            // Pretvaranje niza byte-ova u niz bit-ova [OK]:
            BitArray bit_arr = new BitArray(data);
            BitArray result = new BitArray(bit_arr.Length, false);  // Default su svi 0!

            // Petlja za dekodiranje podataka: [OK]
            for (int i = 0; i < bit_arr.Length; i++)
            {
                bool key_bit = generate_keystream();
                result.Set(i, bit_arr[i] ^ key_bit);
            }

            byte[] result_arr = new byte[(result.Length - 1) / 8 + 1];
            result.CopyTo(result_arr, 0);

            // Vracanje rezultata: [OK]
            string result_str = Encoding.ASCII.GetString(result_arr);
            Console.WriteLine("Decrypted data: " + result_str);
            return result_str;
        }
    }
}
