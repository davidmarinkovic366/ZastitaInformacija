using System.Text;

namespace ZI_Projekat_17738
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_a51_Click(object sender, EventArgs e)
        {
            A5_1Form forma = new A5_1Form();
            forma.ShowDialog();
        }

        private void btn_pfc_Click(object sender, EventArgs e)
        {
            PFCForm forma = new PFCForm();
            forma.ShowDialog();
        }

        private void btn_rsa_Click(object sender, EventArgs e)
        {
            RSAForm forma = new RSAForm();
            forma.ShowDialog();
        }

        private void btn_cfb_Click(object sender, EventArgs e)
        {
            CFBForm forma = new CFBForm();
            forma.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SHA2Form forma = new SHA2Form();
            forma.ShowDialog();
        }

        private void btn_cfb_rsa_Click(object sender, EventArgs e)
        {
            CFB_RSAForm forma = new CFB_RSAForm();
            forma.ShowDialog();
        }
    }
}