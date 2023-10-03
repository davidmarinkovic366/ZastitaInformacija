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
    public partial class CFB_RSAForm : Form
    {
        protected byte[] vector;
        protected byte[] image_data;
        protected string image_path;

        private FileSupport fs;
        private CFB_RSA cfb;


        public CFB_RSAForm()
        {
            InitializeComponent();
            this.btn_encrypt.Enabled = false;
            this.btn_decrypt.Enabled = false;
        }

        private void btn_default_rsa_Click(object sender, EventArgs e)
        {
            this.tbx_p.Text = "7";
            this.tbx_q.Text = "31";
            this.tbx_vector.Text = "initvect";
        }

        private void btn_set_keys_Click(object sender, EventArgs e)
        {
            if(this.tbx_p.Text == "" || this.tbx_p.Text == "" || this.tbx_vector.Text == "")
            {
                MessageBox.Show("Morate prvo da popunite sva polja za inicijalizaciju!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.cfb = new CFB_RSA(Encoding.ASCII.GetBytes(tbx_vector.Text), Int32.Parse(this.tbx_p.Text), Int32.Parse(this.tbx_q.Text));
            MessageBox.Show("Uspesno smo inicijalizovali CFB i RSA", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_load_img_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Bmp Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "bmp",
                Filter = "bmp files (*.bmp)|*.bmp",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.fs = new FileSupport();
                
                this.pbx_data.ImageLocation = openFileDialog1.FileName;
                this.pbx_result.ImageLocation = null;

                this.image_path = openFileDialog1.FileName;
                this.image_data = fs.readBmp(openFileDialog1.FileName);

                this.btn_encrypt.Enabled = true;
                this.btn_decrypt.Enabled = true;

                this.lbl_loaded_path.Text = "Loaded: " + this.image_path;
            }
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            string new_path = this.image_path.Substring(0, image_path.Length - 4) + "Encrypted" + image_path.Substring(image_path.Length - 4, 4);
            this.fs.saveBmp(cfb.encrypt(this.image_data), new_path);

            MessageBox.Show("Uspesno smo sacuvali enkriptovanu sliku na lokaciju: \n" + new_path, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.pbx_result.ImageLocation = new_path;

            this.btn_decrypt.Enabled = false;
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            string new_path = this.image_path.Substring(0, image_path.Length - 4) + "Decrypted" + image_path.Substring(image_path.Length - 4, 4);
            fs.saveBmp(cfb.decrypt(this.image_data), new_path);

            MessageBox.Show("Uspesno smo sacuvali dekriptovanu sliku na lokaciju: \n" + new_path, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.pbx_result.ImageLocation = new_path;

            this.btn_encrypt.Enabled = false;
        }
    }
}
