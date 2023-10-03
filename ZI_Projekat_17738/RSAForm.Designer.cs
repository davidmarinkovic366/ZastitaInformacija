namespace ZI_Projekat_17738
{
    partial class RSAForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_p = new System.Windows.Forms.TextBox();
            this.tbx_q = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_def_keys = new System.Windows.Forms.Button();
            this.rtbx_data = new System.Windows.Forms.RichTextBox();
            this.rtbx_encrypted = new System.Windows.Forms.RichTextBox();
            this.rtbx_decrypted = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_file = new System.Windows.Forms.CheckBox();
            this.btn_file = new System.Windows.Forms.Button();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.btn_save_encrypted = new System.Windows.Forms.Button();
            this.btn_save_decrypted = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "P value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Q value:";
            // 
            // tbx_p
            // 
            this.tbx_p.Location = new System.Drawing.Point(179, 16);
            this.tbx_p.Name = "tbx_p";
            this.tbx_p.Size = new System.Drawing.Size(100, 23);
            this.tbx_p.TabIndex = 2;
            // 
            // tbx_q
            // 
            this.tbx_q.Location = new System.Drawing.Point(179, 45);
            this.tbx_q.Name = "tbx_q";
            this.tbx_q.Size = new System.Drawing.Size(100, 23);
            this.tbx_q.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_def_keys);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbx_q);
            this.groupBox1.Controls.Add(this.tbx_p);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 105);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Init RSA:";
            // 
            // btn_def_keys
            // 
            this.btn_def_keys.Location = new System.Drawing.Point(179, 74);
            this.btn_def_keys.Name = "btn_def_keys";
            this.btn_def_keys.Size = new System.Drawing.Size(100, 23);
            this.btn_def_keys.TabIndex = 4;
            this.btn_def_keys.Text = "Default values";
            this.btn_def_keys.UseVisualStyleBackColor = true;
            this.btn_def_keys.Click += new System.EventHandler(this.btn_def_keys_Click);
            // 
            // rtbx_data
            // 
            this.rtbx_data.Location = new System.Drawing.Point(144, 123);
            this.rtbx_data.Name = "rtbx_data";
            this.rtbx_data.Size = new System.Drawing.Size(153, 96);
            this.rtbx_data.TabIndex = 5;
            this.rtbx_data.Text = "";
            // 
            // rtbx_encrypted
            // 
            this.rtbx_encrypted.Location = new System.Drawing.Point(144, 225);
            this.rtbx_encrypted.Name = "rtbx_encrypted";
            this.rtbx_encrypted.Size = new System.Drawing.Size(153, 96);
            this.rtbx_encrypted.TabIndex = 6;
            this.rtbx_encrypted.Text = "";
            // 
            // rtbx_decrypted
            // 
            this.rtbx_decrypted.Location = new System.Drawing.Point(144, 356);
            this.rtbx_decrypted.Name = "rtbx_decrypted";
            this.rtbx_decrypted.Size = new System.Drawing.Size(153, 96);
            this.rtbx_decrypted.TabIndex = 7;
            this.rtbx_decrypted.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Data:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Encrypted data:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Decrypted data:";
            // 
            // cbx_file
            // 
            this.cbx_file.AutoSize = true;
            this.cbx_file.Location = new System.Drawing.Point(12, 500);
            this.cbx_file.Name = "cbx_file";
            this.cbx_file.Size = new System.Drawing.Size(76, 19);
            this.cbx_file.TabIndex = 11;
            this.cbx_file.Text = "Load file?";
            this.cbx_file.UseVisualStyleBackColor = true;
            this.cbx_file.CheckedChanged += new System.EventHandler(this.cbx_file_CheckedChanged);
            // 
            // btn_file
            // 
            this.btn_file.Location = new System.Drawing.Point(198, 497);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(100, 23);
            this.btn_file.TabIndex = 12;
            this.btn_file.Text = "Chose file";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Location = new System.Drawing.Point(12, 526);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(100, 23);
            this.btn_encrypt.TabIndex = 14;
            this.btn_encrypt.Text = "Encrypt";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.Location = new System.Drawing.Point(198, 526);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(100, 23);
            this.btn_decrypt.TabIndex = 15;
            this.btn_decrypt.Text = "Decrypt";
            this.btn_decrypt.UseVisualStyleBackColor = true;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
            // 
            // btn_save_encrypted
            // 
            this.btn_save_encrypted.Location = new System.Drawing.Point(144, 327);
            this.btn_save_encrypted.Name = "btn_save_encrypted";
            this.btn_save_encrypted.Size = new System.Drawing.Size(153, 23);
            this.btn_save_encrypted.TabIndex = 16;
            this.btn_save_encrypted.Text = "Save encrypted";
            this.btn_save_encrypted.UseVisualStyleBackColor = true;
            this.btn_save_encrypted.Click += new System.EventHandler(this.btn_save_encrypted_Click);
            // 
            // btn_save_decrypted
            // 
            this.btn_save_decrypted.Location = new System.Drawing.Point(145, 458);
            this.btn_save_decrypted.Name = "btn_save_decrypted";
            this.btn_save_decrypted.Size = new System.Drawing.Size(153, 23);
            this.btn_save_decrypted.TabIndex = 17;
            this.btn_save_decrypted.Text = "Save decrypted";
            this.btn_save_decrypted.UseVisualStyleBackColor = true;
            this.btn_save_decrypted.Click += new System.EventHandler(this.btn_save_decrypted_Click);
            // 
            // RSAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 561);
            this.Controls.Add(this.btn_save_decrypted);
            this.Controls.Add(this.btn_save_encrypted);
            this.Controls.Add(this.btn_decrypt);
            this.Controls.Add(this.btn_encrypt);
            this.Controls.Add(this.btn_file);
            this.Controls.Add(this.cbx_file);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbx_decrypted);
            this.Controls.Add(this.rtbx_encrypted);
            this.Controls.Add(this.rtbx_data);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RSAForm";
            this.Text = "RSAForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tbx_p;
        internal TextBox tbx_q;
        private GroupBox groupBox1;
        private Button btn_def_keys;
        private RichTextBox rtbx_data;
        private RichTextBox rtbx_encrypted;
        private RichTextBox rtbx_decrypted;
        private Label label3;
        private Label label4;
        private Label label5;
        private CheckBox cbx_file;
        private Button btn_file;
        private Button btn_encrypt;
        private Button btn_decrypt;
        private Button btn_save_encrypted;
        private Button btn_save_decrypted;
    }
}