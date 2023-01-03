
using System.Diagnostics.Metrics;
using System.Text;

namespace ZI_17738
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //A5_1 encoder = new A5_1("daavid12");
            //byte[] encoded = encoder.encrypt("primer plain teksta podataka:?~");

            //A5_1 decoder = new A5_1("daavid12");
            //decoder.decrypt(encoded);

            //PlayfairCipher pf = new PlayfairCipher("Monarchy");
            //string test = pf.encrypt("primer plain teksta podataka");
            //pf.decrypt(test);

            // FIXME: ne radi lepo, overflow za BigInteger...[]
            //RSA rsa = new RSA(10);
            //string res = rsa.encrypt("KARLSRUHE");
            //rsa.decrypt(res);

            //AES a = new AES((128 / 8), Encoding.ASCII.GetBytes("kljuckljuckljuck"));

            //byte[] buff = Encoding.ASCII.GetBytes("fdksdasd ovo da?");
            //byte[,] data = new byte[4, 4];
            //int counter = 0;
            //for(int i = 0; i < 4; i++)
            //{
            //    for(int j = 0; j < 4; j++)
            //    {
            //        data[i, j] = (byte)buff[counter++];
            //    }
            //}
            //data = a.encrypt(data, "F:\\zi\\encrypt_result.bin");
            //a.decrypt("F:\\zi\\encrypt_result.bin");

            CFB cfb = new CFB(Encoding.ASCII.GetBytes("kljuckljuckljuck"), Encoding.ASCII.GetBytes("initvectoraaaaaa"));
            byte[] res = cfb.encrypt(Encoding.ASCII.GetBytes("fdksdasd ovo da?fdksdasd ovo da2"));

            Console.WriteLine("\n\nWe encoded data: \n");
            foreach (byte b in Encoding.ASCII.GetBytes("fdksdasd ovo da?fdksdasd ovo da2"))
                Console.Write(b + " ");

            Console.WriteLine("\n\n\n\n Decryptinh: \n\n\n\n");

            CFB cfbb = new CFB(Encoding.ASCII.GetBytes("kljuckljuckljuck"), Encoding.ASCII.GetBytes("initvectoraaaaaa"));
            cfbb.decrypt(res);

            Console.ReadLine();
        }
    }

}