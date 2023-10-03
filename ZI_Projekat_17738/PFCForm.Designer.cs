namespace ZI_Projekat_17738
{
    partial class PFCForm
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
            this.tbx_key = new System.Windows.Forms.TextBox();
            this.rtbx_data = new System.Windows.Forms.RichTextBox();
            this.rtbx_encrypted = new System.Windows.Forms.RichTextBox();
            this.rtbx_decrypted = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.cbx_file = new System.Windows.Forms.CheckBox();
            this.btn_file = new System.Windows.Forms.Button();
            this.btn_save_decrypted = new System.Windows.Forms.Button();
            this.btn_save_encrypted = new System.Windows.Forms.Button();
            this.btn_set_default_key = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key:";
            // 
            // tbx_key
            // 
            this.tbx_key.Location = new System.Drawing.Point(127, 12);
            this.tbx_key.Name = "tbx_key";
            this.tbx_key.Size = new System.Drawing.Size(158, 23);
            this.tbx_key.TabIndex = 1;
            // 
            // rtbx_data
            // 
            this.rtbx_data.Location = new System.Drawing.Point(127, 70);
            this.rtbx_data.Name = "rtbx_data";
            this.rtbx_data.Size = new System.Drawing.Size(158, 96);
            this.rtbx_data.TabIndex = 2;
            this.rtbx_data.Text = "";
            // 
            // rtbx_encrypted
            // 
            this.rtbx_encrypted.Location = new System.Drawing.Point(127, 172);
            this.rtbx_encrypted.Name = "rtbx_encrypted";
            this.rtbx_encrypted.Size = new System.Drawing.Size(158, 96);
            this.rtbx_encrypted.TabIndex = 3;
            this.rtbx_encrypted.Text = "";
            // 
            // rtbx_decrypted
            // 
            this.rtbx_decrypted.Location = new System.Drawing.Point(127, 315);
            this.rtbx_decrypted.Name = "rtbx_decrypted";
            this.rtbx_decrypted.Size = new System.Drawing.Size(158, 96);
            this.rtbx_decrypted.TabIndex = 4;
            this.rtbx_decrypted.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Encrypted text:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Decrypted text:";
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Location = new System.Drawing.Point(12, 481);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(87, 23);
            this.btn_encrypt.TabIndex = 8;
            this.btn_encrypt.Text = "Encrypt";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.Location = new System.Drawing.Point(198, 481);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(87, 23);
            this.btn_decrypt.TabIndex = 9;
            this.btn_decrypt.Text = "Decrypt";
            this.btn_decrypt.UseVisualStyleBackColor = true;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
            // 
            // cbx_file
            // 
            this.cbx_file.AutoSize = true;
            this.cbx_file.Location = new System.Drawing.Point(12, 455);
            this.cbx_file.Name = "cbx_file";
            this.cbx_file.Size = new System.Drawing.Size(76, 19);
            this.cbx_file.TabIndex = 10;
            this.cbx_file.Text = "Load file?";
            this.cbx_file.UseVisualStyleBackColor = true;
            this.cbx_file.CheckedChanged += new System.EventHandler(this.cbx_file_CheckedChanged);
            // 
            // btn_file
            // 
            this.btn_file.Location = new System.Drawing.Point(198, 452);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(87, 23);
            this.btn_file.TabIndex = 11;
            this.btn_file.Text = "Chose file";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // btn_save_decrypted
            // 
            this.btn_save_decrypted.Location = new System.Drawing.Point(127, 417);
            this.btn_save_decrypted.Name = "btn_save_decrypted";
            this.btn_save_decrypted.Size = new System.Drawing.Size(158, 23);
            this.btn_save_decrypted.TabIndex = 12;
            this.btn_save_decrypted.Text = "Save decrypted";
            this.btn_save_decrypted.UseVisualStyleBackColor = true;
            this.btn_save_decrypted.Click += new System.EventHandler(this.btn_save_decrypted_Click);
            // 
            // btn_save_encrypted
            // 
            this.btn_save_encrypted.Location = new System.Drawing.Point(127, 274);
            this.btn_save_encrypted.Name = "btn_save_encrypted";
            this.btn_save_encrypted.Size = new System.Drawing.Size(158, 23);
            this.btn_save_encrypted.TabIndex = 13;
            this.btn_save_encrypted.Text = "Save encrypted";
            this.btn_save_encrypted.UseVisualStyleBackColor = true;
            this.btn_save_encrypted.Click += new System.EventHandler(this.btn_save_encrypted_Click);
            // 
            // btn_set_default_key
            // 
            this.btn_set_default_key.Location = new System.Drawing.Point(198, 41);
            this.btn_set_default_key.Name = "btn_set_default_key";
            this.btn_set_default_key.Size = new System.Drawing.Size(87, 23);
            this.btn_set_default_key.TabIndex = 14;
            this.btn_set_default_key.Text = "Set default?";
            this.btn_set_default_key.UseVisualStyleBackColor = true;
            this.btn_set_default_key.Click += new System.EventHandler(this.btn_set_default_key_Click);
            // 
            // PFCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 516);
            this.Controls.Add(this.btn_set_default_key);
            this.Controls.Add(this.btn_save_encrypted);
            this.Controls.Add(this.btn_save_decrypted);
            this.Controls.Add(this.btn_file);
            this.Controls.Add(this.cbx_file);
            this.Controls.Add(this.btn_decrypt);
            this.Controls.Add(this.btn_encrypt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbx_decrypted);
            this.Controls.Add(this.rtbx_encrypted);
            this.Controls.Add(this.rtbx_data);
            this.Controls.Add(this.tbx_key);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PFCForm";
            this.Text = "PFCForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox tbx_key;
        private RichTextBox rtbx_data;
        private RichTextBox rtbx_encrypted;
        private RichTextBox rtbx_decrypted;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btn_encrypt;
        private Button btn_decrypt;
        private CheckBox cbx_file;
        private Button btn_file;
        private Button btn_save_decrypted;
        private Button btn_save_encrypted;
        private Button btn_set_default_key;
    }
}