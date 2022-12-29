
namespace ZI_17738
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //A5_1 a51 = new A5_1("key12378", 17);
            //string key = a51.generate_keystream();

            //Console.WriteLine("Your key: " + key);

            PlayfairCipher pf = new PlayfairCipher("Monarchy");
            string test = pf.encrypt("ovo je primer podatakas");
            pf.decrypt(test);


            Console.ReadLine();
        }
    }

}