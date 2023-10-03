namespace ZI_Projekat_17738
{
    partial class SHA2Form
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
            this.rtbx_sha = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_chose = new System.Windows.Forms.Button();
            this.btn_process = new System.Windows.Forms.Button();
            this.lbl_file = new System.Windows.Forms.Label();
            this.cbx_uporedi = new System.Windows.Forms.CheckBox();
            this.btn_first_file = new System.Windows.Forms.Button();
            this.gbx_combo = new System.Windows.Forms.GroupBox();
            this.btn_compare = new System.Windows.Forms.Button();
            this.lbl_second_file = new System.Windows.Forms.Label();
            this.btn_second_file = new System.Windows.Forms.Button();
            this.lbl_first_file = new System.Windows.Forms.Label();
            this.gbx_combo.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbx_sha
            // 
            this.rtbx_sha.Location = new System.Drawing.Point(12, 88);
            this.rtbx_sha.Name = "rtbx_sha";
            this.rtbx_sha.Size = new System.Drawing.Size(519, 23);
            this.rtbx_sha.TabIndex = 0;
            this.rtbx_sha.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "File:";
            // 
            // btn_chose
            // 
            this.btn_chose.Location = new System.Drawing.Point(434, 15);
            this.btn_chose.Name = "btn_chose";
            this.btn_chose.Size = new System.Drawing.Size(97, 23);
            this.btn_chose.TabIndex = 2;
            this.btn_chose.Text = "Open file";
            this.btn_chose.UseVisualStyleBackColor = true;
            this.btn_chose.Click += new System.EventHandler(this.btn_chose_Click);
            // 
            // btn_process
            // 
            this.btn_process.Location = new System.Drawing.Point(434, 44);
            this.btn_process.Name = "btn_process";
            this.btn_process.Size = new System.Drawing.Size(97, 23);
            this.btn_process.TabIndex = 3;
            this.btn_process.Text = "Process";
            this.btn_process.UseVisualStyleBackColor = true;
            this.btn_process.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // lbl_file
            // 
            this.lbl_file.AutoSize = true;
            this.lbl_file.Location = new System.Drawing.Point(12, 70);
            this.lbl_file.Name = "lbl_file";
            this.lbl_file.Size = new System.Drawing.Size(69, 15);
            this.lbl_file.TabIndex = 4;
            this.lbl_file.Text = "Chosen file:";
            // 
            // cbx_uporedi
            // 
            this.cbx_uporedi.AutoSize = true;
            this.cbx_uporedi.Location = new System.Drawing.Point(12, 117);
            this.cbx_uporedi.Name = "cbx_uporedi";
            this.cbx_uporedi.Size = new System.Drawing.Size(104, 19);
            this.cbx_uporedi.TabIndex = 5;
            this.cbx_uporedi.Text = "Compare files?";
            this.cbx_uporedi.UseVisualStyleBackColor = true;
            this.cbx_uporedi.CheckedChanged += new System.EventHandler(this.cbx_uporedi_CheckedChanged);
            // 
            // btn_first_file
            // 
            this.btn_first_file.Location = new System.Drawing.Point(7, 22);
            this.btn_first_file.Name = "btn_first_file";
            this.btn_first_file.Size = new System.Drawing.Size(97, 23);
            this.btn_first_file.TabIndex = 6;
            this.btn_first_file.Text = "First file";
            this.btn_first_file.UseVisualStyleBackColor = true;
            this.btn_first_file.Click += new System.EventHandler(this.btn_first_file_Click);
            // 
            // gbx_combo
            // 
            this.gbx_combo.Controls.Add(this.btn_compare);
            this.gbx_combo.Controls.Add(this.lbl_second_file);
            this.gbx_combo.Controls.Add(this.btn_second_file);
            this.gbx_combo.Controls.Add(this.lbl_first_file);
            this.gbx_combo.Controls.Add(this.btn_first_file);
            this.gbx_combo.Location = new System.Drawing.Point(12, 142);
            this.gbx_combo.Name = "gbx_combo";
            this.gbx_combo.Size = new System.Drawing.Size(519, 127);
            this.gbx_combo.TabIndex = 7;
            this.gbx_combo.TabStop = false;
            this.gbx_combo.Text = "Compare:";
            // 
            // btn_compare
            // 
            this.btn_compare.Location = new System.Drawing.Point(422, 22);
            this.btn_compare.Name = "btn_compare";
            this.btn_compare.Size = new System.Drawing.Size(91, 23);
            this.btn_compare.TabIndex = 10;
            this.btn_compare.Text = "Compare!";
            this.btn_compare.UseVisualStyleBackColor = true;
            this.btn_compare.Click += new System.EventHandler(this.btn_compare_Click);
            // 
            // lbl_second_file
            // 
            this.lbl_second_file.AutoSize = true;
            this.lbl_second_file.Location = new System.Drawing.Point(7, 103);
            this.lbl_second_file.Name = "lbl_second_file";
            this.lbl_second_file.Size = new System.Drawing.Size(68, 15);
            this.lbl_second_file.TabIndex = 9;
            this.lbl_second_file.Text = "Second file:";
            // 
            // btn_second_file
            // 
            this.btn_second_file.Location = new System.Drawing.Point(7, 77);
            this.btn_second_file.Name = "btn_second_file";
            this.btn_second_file.Size = new System.Drawing.Size(97, 23);
            this.btn_second_file.TabIndex = 8;
            this.btn_second_file.Text = "Second file";
            this.btn_second_file.UseVisualStyleBackColor = true;
            this.btn_second_file.Click += new System.EventHandler(this.btn_second_file_Click);
            // 
            // lbl_first_file
            // 
            this.lbl_first_file.AutoSize = true;
            this.lbl_first_file.Location = new System.Drawing.Point(7, 48);
            this.lbl_first_file.Name = "lbl_first_file";
            this.lbl_first_file.Size = new System.Drawing.Size(51, 15);
            this.lbl_first_file.TabIndex = 7;
            this.lbl_first_file.Text = "First file:";
            // 
            // SHA2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 277);
            this.Controls.Add(this.gbx_combo);
            this.Controls.Add(this.cbx_uporedi);
            this.Controls.Add(this.lbl_file);
            this.Controls.Add(this.btn_process);
            this.Controls.Add(this.btn_chose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbx_sha);
            this.Name = "SHA2Form";
            this.Text = "SHA2Form";
            this.gbx_combo.ResumeLayout(false);
            this.gbx_combo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox rtbx_sha;
        private Label label1;
        private Button btn_chose;
        private Button btn_process;
        private Label lbl_file;
        private CheckBox cbx_uporedi;
        private Button btn_first_file;
        private GroupBox gbx_combo;
        private Button btn_compare;
        private Label lbl_second_file;
        private Button btn_second_file;
        private Label lbl_first_file;
    }
}