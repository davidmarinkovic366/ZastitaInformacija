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
    public partial class SHA2Form : Form
    {
        protected string chosen_file;

        protected string chosen_first_compare;
        protected string chosen_second_compare;

        public SHA2Form()
        {
            InitializeComponent();
            lbl_file.Text = "Chosen file: None";
            this.chosen_file = null;

            this.chosen_first_compare = null;
            this.chosen_second_compare = null;

            this.gbx_combo.Enabled = false;
            this.cbx_uporedi.Checked = false;
        }

        private void btn_chose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.chosen_file = openFileDialog1.FileName;
                this.lbl_file.Text = "Chosen file: " + openFileDialog1.FileName;
            }
        }

        private void btn_process_Click(object sender, EventArgs e)
        {

            if(this.chosen_file == null)
            {
                MessageBox.Show("Please select file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SHA2 sha = new SHA2();
            string result = sha.encrypt(this.chosen_file);

            this.rtbx_sha.Text = result;
        }

        private void btn_first_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.chosen_first_compare = openFileDialog1.FileName;
                this.lbl_first_file.Text = "First file: " + openFileDialog1.FileName;
            }
        }

        private void btn_second_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.chosen_second_compare = openFileDialog1.FileName;
                this.lbl_second_file.Text = "Second file: " + openFileDialog1.FileName;
            }
        }

        private void btn_compare_Click(object sender, EventArgs e)
        {
            if(this.chosen_first_compare != null && this.chosen_second_compare != null)
            {
                SHA2 sha = new SHA2();
                SHA2 sha1 = new SHA2();


                string result_first = sha.encrypt(this.chosen_first_compare);
                string result_second = sha1.encrypt(this.chosen_second_compare);

                if (result_first == result_second)
                    MessageBox.Show("These files are equal, and both have hash value: " + result_first, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("These files are not equal! \nHash(1): " + result_first + "\nHash(2): " + result_second, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select both files first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cbx_uporedi_CheckedChanged(object sender, EventArgs e)
        {
            this.gbx_combo.Enabled = !this.gbx_combo.Enabled;
        }
    }
}
