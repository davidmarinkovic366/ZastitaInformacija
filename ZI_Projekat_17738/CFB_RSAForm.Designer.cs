namespace ZI_Projekat_17738
{
    partial class CFB_RSAForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.tbx_vector = new System.Windows.Forms.TextBox();
            this.btn_set_keys = new System.Windows.Forms.Button();
            this.btn_default_rsa = new System.Windows.Forms.Button();
            this.tbx_q = new System.Windows.Forms.TextBox();
            this.tbx_p = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbx_data = new System.Windows.Forms.PictureBox();
            this.pbx_result = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.btn_load_img = new System.Windows.Forms.Button();
            this.lbl_loaded_path = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_result)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbx_vector);
            this.groupBox1.Controls.Add(this.btn_set_keys);
            this.groupBox1.Controls.Add(this.btn_default_rsa);
            this.groupBox1.Controls.Add(this.tbx_q);
            this.groupBox1.Controls.Add(this.tbx_p);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initialization:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Init. vector:";
            // 
            // tbx_vector
            // 
            this.tbx_vector.Location = new System.Drawing.Point(136, 80);
            this.tbx_vector.Name = "tbx_vector";
            this.tbx_vector.Size = new System.Drawing.Size(118, 23);
            this.tbx_vector.TabIndex = 6;
            // 
            // btn_set_keys
            // 
            this.btn_set_keys.Location = new System.Drawing.Point(6, 109);
            this.btn_set_keys.Name = "btn_set_keys";
            this.btn_set_keys.Size = new System.Drawing.Size(118, 23);
            this.btn_set_keys.TabIndex = 5;
            this.btn_set_keys.Text = "Set keys";
            this.btn_set_keys.UseVisualStyleBackColor = true;
            this.btn_set_keys.Click += new System.EventHandler(this.btn_set_keys_Click);
            // 
            // btn_default_rsa
            // 
            this.btn_default_rsa.Location = new System.Drawing.Point(136, 109);
            this.btn_default_rsa.Name = "btn_default_rsa";
            this.btn_default_rsa.Size = new System.Drawing.Size(118, 23);
            this.btn_default_rsa.TabIndex = 4;
            this.btn_default_rsa.Text = "Set default?";
            this.btn_default_rsa.UseVisualStyleBackColor = true;
            this.btn_default_rsa.Click += new System.EventHandler(this.btn_default_rsa_Click);
            // 
            // tbx_q
            // 
            this.tbx_q.Location = new System.Drawing.Point(136, 51);
            this.tbx_q.Name = "tbx_q";
            this.tbx_q.Size = new System.Drawing.Size(118, 23);
            this.tbx_q.TabIndex = 3;
            // 
            // tbx_p
            // 
            this.tbx_p.Location = new System.Drawing.Point(136, 22);
            this.tbx_p.Name = "tbx_p";
            this.tbx_p.Size = new System.Drawing.Size(118, 23);
            this.tbx_p.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Q value:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "P value:";
            // 
            // pbx_data
            // 
            this.pbx_data.Location = new System.Drawing.Point(154, 162);
            this.pbx_data.Name = "pbx_data";
            this.pbx_data.Size = new System.Drawing.Size(118, 116);
            this.pbx_data.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_data.TabIndex = 1;
            this.pbx_data.TabStop = false;
            // 
            // pbx_result
            // 
            this.pbx_result.Location = new System.Drawing.Point(154, 299);
            this.pbx_result.Name = "pbx_result";
            this.pbx_result.Size = new System.Drawing.Size(118, 116);
            this.pbx_result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbx_result.TabIndex = 2;
            this.pbx_result.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Loaded image:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Result image:";
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.Location = new System.Drawing.Point(12, 362);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(118, 23);
            this.btn_decrypt.TabIndex = 5;
            this.btn_decrypt.Text = "Decrypt loaded";
            this.btn_decrypt.UseVisualStyleBackColor = true;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_decrypt_Click);
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Location = new System.Drawing.Point(12, 333);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(118, 23);
            this.btn_encrypt.TabIndex = 6;
            this.btn_encrypt.Text = "Encrypt loaded";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_encrypt_Click);
            // 
            // btn_load_img
            // 
            this.btn_load_img.Location = new System.Drawing.Point(12, 162);
            this.btn_load_img.Name = "btn_load_img";
            this.btn_load_img.Size = new System.Drawing.Size(118, 23);
            this.btn_load_img.TabIndex = 7;
            this.btn_load_img.Text = "Load image";
            this.btn_load_img.UseVisualStyleBackColor = true;
            this.btn_load_img.Click += new System.EventHandler(this.btn_load_img_Click);
            // 
            // lbl_loaded_path
            // 
            this.lbl_loaded_path.AutoSize = true;
            this.lbl_loaded_path.Location = new System.Drawing.Point(12, 453);
            this.lbl_loaded_path.Name = "lbl_loaded_path";
            this.lbl_loaded_path.Size = new System.Drawing.Size(49, 15);
            this.lbl_loaded_path.TabIndex = 8;
            this.lbl_loaded_path.Text = "Loaded:";
            // 
            // CFB_RSAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 477);
            this.Controls.Add(this.lbl_loaded_path);
            this.Controls.Add(this.btn_load_img);
            this.Controls.Add(this.btn_encrypt);
            this.Controls.Add(this.btn_decrypt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbx_result);
            this.Controls.Add(this.pbx_data);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CFB_RSAForm";
            this.Text = "CFB & RSA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox1;
        private Button btn_default_rsa;
        private TextBox tbx_q;
        private TextBox tbx_p;
        private Label label2;
        private Label label1;
        private Button btn_set_keys;
        private Label label3;
        private TextBox tbx_vector;
        private PictureBox pbx_data;
        private PictureBox pbx_result;
        private Label label4;
        private Label label5;
        private Button btn_decrypt;
        private Button btn_encrypt;
        private Button btn_load_img;
        private Label lbl_loaded_path;
    }
}