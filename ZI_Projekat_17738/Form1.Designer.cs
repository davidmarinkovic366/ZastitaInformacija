namespace ZI_Projekat_17738
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btn_a51 = new System.Windows.Forms.Button();
            this.btn_pfc = new System.Windows.Forms.Button();
            this.btn_rsa = new System.Windows.Forms.Button();
            this.btn_cfb = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_cfb_rsa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select an algorithm:";
            // 
            // btn_a51
            // 
            this.btn_a51.Location = new System.Drawing.Point(23, 38);
            this.btn_a51.Name = "btn_a51";
            this.btn_a51.Size = new System.Drawing.Size(192, 47);
            this.btn_a51.TabIndex = 1;
            this.btn_a51.Text = "A5/1";
            this.btn_a51.UseVisualStyleBackColor = true;
            this.btn_a51.Click += new System.EventHandler(this.btn_a51_Click);
            // 
            // btn_pfc
            // 
            this.btn_pfc.Location = new System.Drawing.Point(23, 91);
            this.btn_pfc.Name = "btn_pfc";
            this.btn_pfc.Size = new System.Drawing.Size(192, 47);
            this.btn_pfc.TabIndex = 2;
            this.btn_pfc.Text = "Playfair Cipher";
            this.btn_pfc.UseVisualStyleBackColor = true;
            this.btn_pfc.Click += new System.EventHandler(this.btn_pfc_Click);
            // 
            // btn_rsa
            // 
            this.btn_rsa.Location = new System.Drawing.Point(23, 144);
            this.btn_rsa.Name = "btn_rsa";
            this.btn_rsa.Size = new System.Drawing.Size(192, 47);
            this.btn_rsa.TabIndex = 3;
            this.btn_rsa.Text = "RSA";
            this.btn_rsa.UseVisualStyleBackColor = true;
            this.btn_rsa.Click += new System.EventHandler(this.btn_rsa_Click);
            // 
            // btn_cfb
            // 
            this.btn_cfb.Location = new System.Drawing.Point(23, 197);
            this.btn_cfb.Name = "btn_cfb";
            this.btn_cfb.Size = new System.Drawing.Size(192, 47);
            this.btn_cfb.TabIndex = 4;
            this.btn_cfb.Text = "CFB / AES";
            this.btn_cfb.UseVisualStyleBackColor = true;
            this.btn_cfb.Click += new System.EventHandler(this.btn_cfb_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 47);
            this.button1.TabIndex = 5;
            this.button1.Text = "SHA2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_cfb_rsa
            // 
            this.btn_cfb_rsa.Location = new System.Drawing.Point(23, 250);
            this.btn_cfb_rsa.Name = "btn_cfb_rsa";
            this.btn_cfb_rsa.Size = new System.Drawing.Size(192, 47);
            this.btn_cfb_rsa.TabIndex = 6;
            this.btn_cfb_rsa.Text = "CFB / RSA";
            this.btn_cfb_rsa.UseVisualStyleBackColor = true;
            this.btn_cfb_rsa.Click += new System.EventHandler(this.btn_cfb_rsa_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 361);
            this.Controls.Add(this.btn_cfb_rsa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_cfb);
            this.Controls.Add(this.btn_rsa);
            this.Controls.Add(this.btn_pfc);
            this.Controls.Add(this.btn_a51);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "17738 - Z4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btn_a51;
        private Button btn_pfc;
        private Button btn_rsa;
        private Button btn_cfb;
        private Button button1;
        private Button btn_cfb_rsa;
    }
}