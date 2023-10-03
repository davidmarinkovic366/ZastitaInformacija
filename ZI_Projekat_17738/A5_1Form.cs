using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ZI_Projekat_17738
{
    public partial class A5_1Form : Form
    {

        protected string file_path;
        protected byte[] saved_data;

        public A5_1Form()
        {
            InitializeComponent();
            this.cbx_file.Checked = false;
            this.btn_chose_file.Enabled = false;
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {

            string key = this.tbx_key.Text.ToLower();
            key = key.Substring(0, 8);

            A5_1 a = new A5_1(key);
            this.saved_data = a.encrypt(this.rtbx_data.Text);
            string encrypted_data = Encoding.UTF8.GetString(this.saved_data);

            this.rtbx_encrypted.Text = encrypted_data;
            this.rtbx_decrypted.Text = null;
        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            string key = this.tbx_key.Text.ToLower();
            key = key.Substring(0, 8);

            A5_1 a = new A5_1(key);
            //this.saved_data = Encoding.UTF8.GetBytes(this.rtbx_encrypted.Text);
            string decrypted_data = a.decrypt(this.saved_data);
   
            this.rtbx_decrypted.Text = decrypted_data;
        }

        private void cbx_file_CheckedChanged(object sender, EventArgs e)
        {
            this.btn_chose_file.Enabled = !this.btn_chose_file.Enabled;
        }

        private void btn_chose_file_Click(object sender, EventArgs e)
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

        private void btn_default_key_Click(object sender, EventArgs e)
        {
            this.tbx_key.Text = "daavid12";
        }
    }
}
