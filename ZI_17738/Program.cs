
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

            AES a = new AES((256 / 8), Encoding.ASCII.GetBytes("kljuckljuckljuckljuckljukrpsmrit"));
            
            byte[] buff = Encoding.ASCII.GetBytes("fdasdasd ovo da enkript?krpsmrit");
            byte[,] data = new byte[4, 8];
            int counter = 0;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    data[i, j] = (byte)buff[counter++];
                }
            }
            a.encrypt(data, "F:\\zi\\encrypt_result.bin");


            Console.ReadLine();
        }
    }

}