using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZI_Projekat_17738
{
    public partial class RSAForm : Form
    {
        protected string file_path;

        public RSAForm()
        {
            InitializeComponent();

            this.cbx_file.Checked = false;
            this.btn_file.Enabled = false;

            this.file_path = null;
        }

        private void btn_def_keys_Click(object sender, EventArgs e)
        {
            this.tbx_p.Text = "17";
            this.tbx_q.Text = "23";
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            RSA rsa = new RSA(Int32.Parse(this.tbx_p.Text), Int32.Parse(this.tbx_q.Text));

            uint[] encrypted = rsa.encrypt(Encoding.ASCII.GetBytes(this.rtbx_data.Text));
            string result = "";

            foreach(uint u in encrypted) 
            {
                result += u.ToString() + " ";
            }
            
            this.rtbx_encrypted.Text = result;
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            RSA rsa = new RSA(Int32.Parse(this.tbx_p.Text), Int32.Parse(this.tbx_q.Text));
            List<uint> data = new List<uint>();
            int block_size = rsa.k;
            
            string[] split_data = this.rtbx_data.Text.Split(' ').SkipLast(1).ToArray();

            foreach (string str in split_data)
                data.Add(UInt32.Parse(str));

            string decrypted_data = Encoding.ASCII.GetString(rsa.decrypt(data.ToArray()));
            this.rtbx_decrypted.Text = decrypted_data;
        }

        private void cbx_file_CheckedChanged(object sender, EventArgs e)
        {
            this.btn_file.Enabled = !this.btn_file.Enabled;
        }

        private void btn_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileSupport fs = new FileSupport();
                this.rtbx_data.Text = Encoding.ASCII.GetString(fs.readTxt(openFileDialog1.FileName));
                this.file_path = openFileDialog1.FileName;
            }
        }

        private void btn_save_encrypted_Click(object sender, EventArgs e)
        {
            if(this.file_path != null)
            {
                string file_encrypted_path = this.file_path.Substring(0, this.file_path.Length - 4);
                string extension = this.file_path.Substring(this.file_path.Length - 4, this.file_path.Length);
                file_encrypted_path += "Encrypted";
                file_encrypted_path += extension;

                File.WriteAllText(file_encrypted_path, this.rtbx_encrypted.Text);
                MessageBox.Show("Uspesno smo sacuvali podatke u fajl: \n" + file_encrypted_path, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Browse Text Files",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "txt",
                    Filter = "txt files (*.txt)|*.txt",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(openFileDialog1.FileName, this.rtbx_encrypted.Text);
                    MessageBox.Show("Uspesno smo sacuvali podatke u fajl: " + openFileDialog1.FileName, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btn_save_decrypted_Click(object sender, EventArgs e)
        {
            if (this.file_path != null)
            {
                string file_decrypted_path = this.file_path.Substring(0, this.file_path.Length - 4);
                string extension = this.file_path.Substring(this.file_path.Length - 4, this.file_path.Length);
                file_decrypted_path += "Decrypted";
                file_decrypted_path += extension;

                File.WriteAllText(file_decrypted_path, this.rtbx_decrypted.Text);
                MessageBox.Show("Uspesno smo sacuvali podatke u fajl: \n" + file_decrypted_path, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Browse Text Files",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "txt",
                    Filter = "txt files (*.txt)|*.txt",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(openFileDialog1.FileName, this.rtbx_encrypted.Text);
                    MessageBox.Show("Uspesno smo sacuvali podatke u fajl: " + openFileDialog1.FileName, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        //private void cbx_image_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.btn_image.Enabled = !this.btn_image.Enabled;
        //    this.btn_save_image.Enabled = !this.btn_save_image.Enabled;
        //}

        //private void btn_image_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog
        //    {
        //        InitialDirectory = @"C:\",
        //        Title = "Browse Text Files",

        //        CheckFileExists = true,
        //        CheckPathExists = true,

        //        DefaultExt = "bmp",
        //        Filter = "bmp files (*.bmp)|*.bmp",
        //        FilterIndex = 2,
        //        RestoreDirectory = true,

        //        ReadOnlyChecked = true,
        //        ShowReadOnly = true
        //    };

        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        //FileSupport fs = new FileSupport();
        //        //this.rtbx_data.Text = Encoding.ASCII.GetString(fs.readTxt());
        //        this.pbx_image.ImageLocation = openFileDialog1.FileName;
        //        this.image_path = openFileDialog1.FileName;
        //        this.image_encrypted_path = this.image_path.Substring(0, image_path.Length - 4);
        //        this.image_encrypted_path += "encrypted.bmp";

        //        this.image = fs.readBmp(openFileDialog1.FileName);
        //        //this.file = openFileDialog1.FileName;
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
