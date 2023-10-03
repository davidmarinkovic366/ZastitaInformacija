using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZI_Projekat_17738
{
    internal class FileSupport
    {
        protected byte[] bmp_header;
        protected string bmp_path;
        protected string txt_path;


        public FileSupport() { }

        public byte[] readTxt(string path)
        {
            this.txt_path = path;
            return File.ReadAllBytes(path);
        }

        public void saveTxt(string path, byte[] data)
        {
            // Pretvaranje niza byte-ova u string:
            string str_data = Encoding.ASCII.GetString(data);
            File.WriteAllText(path, str_data);
        }

        public byte[] readBmp(string path)
        {
            byte[] data = File.ReadAllBytes(path);

            this.bmp_header = data.Take(54).ToArray();
            this.bmp_path = path;

            return data.Skip(54).ToArray();
        }

        public void saveBmp(byte[] data, string path)
        {
            byte[] image = this.bmp_header;
            image = image.Concat(data).ToArray();

            string image_path = this.bmp_path.Substring(0, bmp_path.Length - 4);
            image_path += "encrypted.bmp";

            File.WriteAllBytes(path, image);
        }

    }
}
