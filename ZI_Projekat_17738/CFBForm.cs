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
    public partial class CFBForm : Form
    {
        protected byte[] image;
        protected byte[] encrypted_data;
        protected string file_path;
        protected string file_path_img;
        protected string file_path_img_encrypted;

        private FileSupport fs;

        public CFBForm()
        {
            InitializeComponent();
            this.cbx_file.Checked = false;
            this.cbx_save_file.Checked = false;
            this.cbx_save_file.Enabled = false;
            this.btn_file.Enabled = false;

            this.cbx_image.Checked = false;
            //this.cbx_save_image.Checked = false;
            //this.cbx_save_image.Enabled = false;
            this.btn_image.Enabled = false;

            fs = new FileSupport();
        }

        private void btn_def_init_Click(object sender, EventArgs e)
        {
            this.tbx_aes_key.Text = "kljuckljuckljuck";
            this.tbx_init_vec.Text = "initvectoraaaaaa";
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            CFB cfb = new CFB(Encoding.ASCII.GetBytes(this.tbx_aes_key.Text), Encoding.ASCII.GetBytes(this.tbx_init_vec.Text));
            if (this.cbx_image.Checked)
            {
                //this.image = fs.readBmp(this.file_path_img);
                this.encrypted_data = cfb.encrypt(this.image);
                string location = this.file_path_img.Substring(0, file_path_img.Length - 4) + "Encrypted" + this.file_path_img.Substring(file_path_img.Length - 4, 4);

                fs.saveBmp(encrypted_data, location);
                this.pbx_result.ImageLocation = location;
                MessageBox.Show("Slika uspesno sacuvana na lokaciji: \n" + location, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.encrypted_data = cfb.encrypt(Encoding.ASCII.GetBytes(this.rtbx_data.Text));
                this.rtbx_encrypted.Text = Encoding.ASCII.GetString(this.encrypted_data);
                this.rtbx_decrypted.Text = null;
            }

        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            CFB cfb = new CFB(Encoding.ASCII.GetBytes(this.tbx_aes_key.Text), Encoding.ASCII.GetBytes(this.tbx_init_vec.Text));
            if (this.cbx_image.Checked)
            {
                byte[] data = cfb.decrypt(this.image);
                string location = this.file_path_img.Substring(0, file_path_img.Length - 4) + "Decrypted" + this.file_path_img.Substring(file_path_img.Length - 4, 4);

                fs.saveBmp(data, location);
                this.pbx_result.ImageLocation = location;
                MessageBox.Show("Slika uspesno sacuvana na lokaciji: \n" + location, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string decrypted_data = Encoding.ASCII.GetString(cfb.decrypt(this.encrypted_data));
                this.rtbx_decrypted.Text = decrypted_data;
            }
        }

        private void cbx_file_CheckedChanged(object sender, EventArgs e)
        {
            this.cbx_save_file.Enabled = !this.cbx_save_file.Enabled;
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

        private void cbx_image_CheckedChanged(object sender, EventArgs e)
        {
            this.cbx_file.Checked = false;
            //this.cbx_save_image.Enabled = !this.cbx_save_image.Enabled;
            this.btn_image.Enabled = !this.btn_image.Enabled;
        }

        private void btn_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "bmp files (*.bmp)|*.bmp",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //FileSupport fs = new FileSupport();
                //this.rtbx_data.Text = Encoding.ASCII.GetString(fs.readTxt(openFileDialog1.FileName));
                this.file_path_img = openFileDialog1.FileName;
                this.pbx_data.ImageLocation = file_path_img;

                string image_path = this.file_path_img.Substring(file_path_img.Length - 4);
                image_path += "encrypted.bmp";
                
                this.file_path_img_encrypted = image_path;
                this.image = fs.readBmp(file_path_img);

                this.pbx_result.ImageLocation = null;
            }
        }
    }
}
