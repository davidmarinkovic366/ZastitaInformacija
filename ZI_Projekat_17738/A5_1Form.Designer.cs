namespace ZI_Projekat_17738
{
    partial class A5_1Form
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
            this.tbx_key = new System.Windows.Forms.TextBox();
            this.lbl_key = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbx_data = new System.Windows.Forms.RichTextBox();
            this.rtbx_encrypted = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbx_decrypted = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_chose_file = new System.Windows.Forms.Button();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.cbx_file = new System.Windows.Forms.CheckBox();
            this.btn_default_key = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbx_key
            // 
            this.tbx_key.Location = new System.Drawing.Point(150, 25);
            this.tbx_key.Name = "tbx_key";
            this.tbx_key.Size = new System.Drawing.Size(155, 23);
            this.tbx_key.TabIndex = 0;
            // 
            // lbl_key
            // 
            this.lbl_key.AutoSize = true;
            this.lbl_key.Location = new System.Drawing.Point(12, 28);
            this.lbl_key.Name = "lbl_key";
            this.lbl_key.Size = new System.Drawing.Size(53, 15);
            this.lbl_key.TabIndex = 1;
            this.lbl_key.Text = "Key (8B):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data:";
            // 
            // rtbx_data
            // 
            this.rtbx_data.Location = new System.Drawing.Point(150, 96);
            this.rtbx_data.Name = "rtbx_data";
            this.rtbx_data.Size = new System.Drawing.Size(155, 96);
            this.rtbx_data.TabIndex = 3;
            this.rtbx_data.Text = "";
            // 
            // rtbx_encrypted
            // 
            this.rtbx_encrypted.Location = new System.Drawing.Point(150, 198);
            this.rtbx_encrypted.Name = "rtbx_encrypted";
            this.rtbx_encrypted.Size = new System.Drawing.Size(155, 96);
            this.rtbx_encrypted.TabIndex = 4;
            this.rtbx_encrypted.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Encrypted data:";
            // 
            // rtbx_decrypted
            // 
            this.rtbx_decrypted.Location = new System.Drawing.Point(150, 300);
            this.rtbx_decrypted.Name = "rtbx_decrypted";
            this.rtbx_decrypted.Size = new System.Drawing.Size(155, 96);
            this.rtbx_decrypted.TabIndex = 6;
            this.rtbx_decrypted.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Decrypted data:";
            // 
            // btn_chose_file
            // 
            this.btn_chose_file.Location = new System.Drawing.Point(197, 415);
            this.btn_chose_file.Name = "btn_chose_file";
            this.btn_chose_file.Size = new System.Drawing.Size(108, 23);
            this.btn_chose_file.TabIndex = 9;
            this.btn_chose_file.Text = "Select file";
            this.btn_chose_file.UseVisualStyleBackColor = true;
            this.btn_chose_file.Click += new System.EventHandler(this.btn_chose_file_Click);
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Location = new System.Drawing.Point(12, 443);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(108, 23);
            this.btn_encrypt.TabIndex = 10;
            this.btn_encrypt.Text = "Encrypt";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.Location = new System.Drawing.Point(197, 443);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(108, 23);
            this.btn_decrypt.TabIndex = 11;
            this.btn_decrypt.Text = "Decrypt";
            this.btn_decrypt.UseVisualStyleBackColor = true;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
            // 
            // cbx_file
            // 
            this.cbx_file.AutoSize = true;
            this.cbx_file.Location = new System.Drawing.Point(12, 418);
            this.cbx_file.Name = "cbx_file";
            this.cbx_file.Size = new System.Drawing.Size(76, 19);
            this.cbx_file.TabIndex = 12;
            this.cbx_file.Text = "Load file?";
            this.cbx_file.UseVisualStyleBackColor = true;
            this.cbx_file.CheckedChanged += new System.EventHandler(this.cbx_file_CheckedChanged);
            // 
            // btn_default_key
            // 
            this.btn_default_key.Location = new System.Drawing.Point(197, 54);
            this.btn_default_key.Name = "btn_default_key";
            this.btn_default_key.Size = new System.Drawing.Size(108, 23);
            this.btn_default_key.TabIndex = 13;
            this.btn_default_key.Text = "Set default?";
            this.btn_default_key.UseVisualStyleBackColor = true;
            this.btn_default_key.Click += new System.EventHandler(this.btn_default_key_Click);
            // 
            // A5_1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 473);
            this.Controls.Add(this.btn_default_key);
            this.Controls.Add(this.cbx_file);
            this.Controls.Add(this.btn_decrypt);
            this.Controls.Add(this.btn_encrypt);
            this.Controls.Add(this.btn_chose_file);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbx_decrypted);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbx_encrypted);
            this.Controls.Add(this.rtbx_data);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_key);
            this.Controls.Add(this.tbx_key);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "A5_1Form";
            this.Text = "A5/1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbx_key;
        private Label lbl_key;
        private Label label1;
        private RichTextBox rtbx_data;
        private RichTextBox rtbx_encrypted;
        private Label label2;
        private RichTextBox rtbx_decrypted;
        private Label label3;
        private Button btn_chose_file;
        private Button btn_encrypt;
        private Button btn_decrypt;
        private CheckBox cbx_file;
        private Button btn_default_key;
    }
}