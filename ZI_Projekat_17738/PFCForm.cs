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
    public partial class PFCForm : Form
    {
        protected string key;
        protected string file_path;

        public PFCForm()
        {
            InitializeComponent();
            this.cbx_file.Checked = false;
            this.btn_file.Enabled = false;
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            if(this.tbx_key.Text == "")
            {
                MessageBox.Show("Morate prvo da unesete kljuc!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PlayfairCipher pc = new PlayfairCipher(this.tbx_key.Text);
            this.rtbx_encrypted.Text = pc.encrypt(this.rtbx_data.Text);

        }

        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            if (this.tbx_key.Text == "")
            {
                MessageBox.Show("Morate prvo da unesete kljuc!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PlayfairCipher pc = new PlayfairCipher(this.tbx_key.Text);
            this.rtbx_decrypted.Text = pc.decrypt(this.rtbx_data.Text);
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

        private void btn_set_default_key_Click(object sender, EventArgs e)
        {
            this.tbx_key.Text = "Monarchy";
        }

        private void btn_save_encrypted_Click(object sender, EventArgs e)
        {
            if (this.file_path != null)
            {
                string file_encrypted_path = this.file_path.Substring(0, this.file_path.Length - 4);
                string extension = this.file_path.Substring(this.file_path.Length - 4, 4);
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
                string extension = this.file_path.Substring(this.file_path.Length - 4, 4);
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
                    File.WriteAllText(openFileDialog1.FileName, this.rtbx_decrypted.Text);
                    MessageBox.Show("Uspesno smo sacuvali podatke u fajl: " + openFileDialog1.FileName, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
    }
}
