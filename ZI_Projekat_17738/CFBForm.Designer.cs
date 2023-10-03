namespace ZI_Projekat_17738
{
    partial class CFBForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_def_init = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_init_vec = new System.Windows.Forms.TextBox();
            this.tbx_aes_key = new System.Windows.Forms.TextBox();
            this.rtbx_data = new System.Windows.Forms.RichTextBox();
            this.rtbx_encrypted = new System.Windows.Forms.RichTextBox();
            this.rtbx_decrypted = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.cbx_file = new System.Windows.Forms.CheckBox();
            this.btn_file = new System.Windows.Forms.Button();
            this.cbx_save_file = new System.Windows.Forms.CheckBox();
            this.cbx_image = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_image = new System.Windows.Forms.Button();
            this.pbx_data = new System.Windows.Forms.PictureBox();
            this.pbx_result = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_result)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_def_init);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbx_init_vec);
            this.groupBox1.Controls.Add(this.tbx_aes_key);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CFB initialization:";
            // 
            // btn_def_init
            // 
            this.btn_def_init.Location = new System.Drawing.Point(154, 80);
            this.btn_def_init.Name = "btn_def_init";
            this.btn_def_init.Size = new System.Drawing.Size(100, 23);
            this.btn_def_init.TabIndex = 4;
            this.btn_def_init.Text = "Set default?";
            this.btn_def_init.UseVisualStyleBackColor = true;
            this.btn_def_init.Click += new System.EventHandler(this.btn_def_init_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "CFB vector (128b):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "AES key (128b):";
            // 
            // tbx_init_vec
            // 
            this.tbx_init_vec.Location = new System.Drawing.Point(154, 51);
            this.tbx_init_vec.Name = "tbx_init_vec";
            this.tbx_init_vec.Size = new System.Drawing.Size(100, 23);
            this.tbx_init_vec.TabIndex = 1;
            // 
            // tbx_aes_key
            // 
            this.tbx_aes_key.Location = new System.Drawing.Point(154, 22);
            this.tbx_aes_key.Name = "tbx_aes_key";
            this.tbx_aes_key.Size = new System.Drawing.Size(100, 23);
            this.tbx_aes_key.TabIndex = 0;
            // 
            // rtbx_data
            // 
            this.rtbx_data.Location = new System.Drawing.Point(124, 132);
            this.rtbx_data.Name = "rtbx_data";
            this.rtbx_data.Size = new System.Drawing.Size(148, 96);
            this.rtbx_data.TabIndex = 1;
            this.rtbx_data.Text = "";
            // 
            // rtbx_encrypted
            // 
            this.rtbx_encrypted.Location = new System.Drawing.Point(124, 234);
            this.rtbx_encrypted.Name = "rtbx_encrypted";
            this.rtbx_encrypted.Size = new System.Drawing.Size(148, 96);
            this.rtbx_encrypted.TabIndex = 2;
            this.rtbx_encrypted.Text = "";
            // 
            // rtbx_decrypted
            // 
            this.rtbx_decrypted.Location = new System.Drawing.Point(124, 336);
            this.rtbx_decrypted.Name = "rtbx_decrypted";
            this.rtbx_decrypted.Size = new System.Drawing.Size(148, 96);
            this.rtbx_decrypted.TabIndex = 3;
            this.rtbx_decrypted.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Plaintext:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Encrypted text:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Decrypted text:";
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Location = new System.Drawing.Point(12, 596);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(100, 23);
            this.btn_encrypt.TabIndex = 7;
            this.btn_encrypt.Text = "Encrypt";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.Location = new System.Drawing.Point(349, 596);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(100, 23);
            this.btn_decrypt.TabIndex = 8;
            this.btn_decrypt.Text = "Decrypt";
            this.btn_decrypt.UseVisualStyleBackColor = true;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
            // 
            // cbx_file
            // 
            this.cbx_file.AutoSize = true;
            this.cbx_file.Location = new System.Drawing.Point(6, 25);
            this.cbx_file.Name = "cbx_file";
            this.cbx_file.Size = new System.Drawing.Size(76, 19);
            this.cbx_file.TabIndex = 9;
            this.cbx_file.Text = "Load file?";
            this.cbx_file.UseVisualStyleBackColor = true;
            this.cbx_file.CheckedChanged += new System.EventHandler(this.cbx_file_CheckedChanged);
            // 
            // btn_file
            // 
            this.btn_file.Location = new System.Drawing.Point(331, 22);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(100, 23);
            this.btn_file.TabIndex = 10;
            this.btn_file.Text = "Select file";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // cbx_save_file
            // 
            this.cbx_save_file.AutoSize = true;
            this.cbx_save_file.Location = new System.Drawing.Point(6, 50);
            this.cbx_save_file.Name = "cbx_save_file";
            this.cbx_save_file.Size = new System.Drawing.Size(87, 19);
            this.cbx_save_file.TabIndex = 11;
            this.cbx_save_file.Text = "Save result?";
            this.cbx_save_file.UseVisualStyleBackColor = true;
            // 
            // cbx_image
            // 
            this.cbx_image.AutoSize = true;
            this.cbx_image.Location = new System.Drawing.Point(6, 25);
            this.cbx_image.Name = "cbx_image";
            this.cbx_image.Size = new System.Drawing.Size(93, 19);
            this.cbx_image.TabIndex = 12;
            this.cbx_image.Text = "Load image?";
            this.cbx_image.UseVisualStyleBackColor = true;
            this.cbx_image.CheckedChanged += new System.EventHandler(this.cbx_image_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbx_file);
            this.groupBox2.Controls.Add(this.cbx_save_file);
            this.groupBox2.Controls.Add(this.btn_file);
            this.groupBox2.Location = new System.Drawing.Point(12, 438);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 76);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Txt";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_image);
            this.groupBox3.Controls.Add(this.cbx_image);
            this.groupBox3.Location = new System.Drawing.Point(12, 520);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 60);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bmp";
            // 
            // btn_image
            // 
            this.btn_image.Location = new System.Drawing.Point(331, 22);
            this.btn_image.Name = "btn_image";
            this.btn_image.Size = new System.Drawing.Size(100, 23);
            this.btn_image.TabIndex = 10;
            this.btn_image.Text = "Select file";
            this.btn_image.UseVisualStyleBackColor = true;
            this.btn_image.Click += new System.EventHandler(this.btn_image_Click);
            // 
            // pbx_data
            // 
            this.pbx_data.Location = new System.Drawing.Point(295, 83);
            this.pbx_data.Name = "pbx_data";
            this.pbx_data.Size = new System.Drawing.Size(148, 134);
            this.pbx_data.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_data.TabIndex = 16;
            this.pbx_data.TabStop = false;
            // 
            // pbx_result
            // 
            this.pbx_result.Location = new System.Drawing.Point(295, 275);
            this.pbx_result.Name = "pbx_result";
            this.pbx_result.Size = new System.Drawing.Size(148, 134);
            this.pbx_result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_result.TabIndex = 17;
            this.pbx_result.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Data image";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 412);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Result image";
            // 
            // CFBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 628);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pbx_result);
            this.Controls.Add(this.pbx_data);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_decrypt);
            this.Controls.Add(this.btn_encrypt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbx_decrypted);
            this.Controls.Add(this.rtbx_encrypted);
            this.Controls.Add(this.rtbx_data);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CFBForm";
            this.Text = "CFB & AES(128)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_def_init;
        private Label label2;
        private Label label1;
        private TextBox tbx_init_vec;
        private TextBox tbx_aes_key;
        private RichTextBox rtbx_data;
        private RichTextBox rtbx_encrypted;
        private RichTextBox rtbx_decrypted;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btn_encrypt;
        private Button btn_decrypt;
        private CheckBox cbx_file;
        private Button btn_file;
        private CheckBox cbx_save_file;
        private CheckBox cbx_image;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btn_image;
        private PictureBox pbx_data;
        private PictureBox pbx_result;
        private Label label6;
        private Label label7;
    }
}