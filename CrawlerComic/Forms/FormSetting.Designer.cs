namespace CrawlerComic.Forms
{
    partial class FormSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.txtWebs = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFolderDownload = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ckbOffAlert = new System.Windows.Forms.CheckBox();
            this.nudMaxProcessDownload = new System.Windows.Forms.NumericUpDown();
            this.ckbAutoStart = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.btnSelectFolder = new FontAwesome.Sharp.IconButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.btnSaveSetting = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxProcessDownload)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtWebs
            // 
            this.txtWebs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebs.Location = new System.Drawing.Point(151, 6);
            this.txtWebs.Multiline = true;
            this.txtWebs.Name = "txtWebs";
            this.txtWebs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWebs.Size = new System.Drawing.Size(520, 269);
            this.txtWebs.TabIndex = 1;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(152, 113);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(190, 17);
            this.radioButton3.TabIndex = 14;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Tách mỗi chapter là 1 thư mục ảnh";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(152, 90);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(162, 17);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Tách mỗi chapter là 1 file pdf";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(152, 69);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(237, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Gộp các chapter cùng 1 truyện vào 1 file pdf";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hình thức tải";
            // 
            // txtFolderDownload
            // 
            this.txtFolderDownload.Location = new System.Drawing.Point(151, 42);
            this.txtFolderDownload.Name = "txtFolderDownload";
            this.txtFolderDownload.Size = new System.Drawing.Size(421, 20);
            this.txtFolderDownload.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Thư mục lưu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số luồng tải tối đa cùng lúc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "MetaData web truyện";
            // 
            // ckbOffAlert
            // 
            this.ckbOffAlert.AutoSize = true;
            this.ckbOffAlert.Location = new System.Drawing.Point(148, 17);
            this.ckbOffAlert.Name = "ckbOffAlert";
            this.ckbOffAlert.Size = new System.Drawing.Size(93, 17);
            this.ckbOffAlert.TabIndex = 16;
            this.ckbOffAlert.Text = "Tắt thông báo";
            this.ckbOffAlert.UseVisualStyleBackColor = true;
            // 
            // nudMaxProcessDownload
            // 
            this.nudMaxProcessDownload.Location = new System.Drawing.Point(152, 16);
            this.nudMaxProcessDownload.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMaxProcessDownload.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxProcessDownload.Name = "nudMaxProcessDownload";
            this.nudMaxProcessDownload.Size = new System.Drawing.Size(42, 20);
            this.nudMaxProcessDownload.TabIndex = 17;
            this.nudMaxProcessDownload.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ckbAutoStart
            // 
            this.ckbAutoStart.AutoSize = true;
            this.ckbAutoStart.Location = new System.Drawing.Point(148, 39);
            this.ckbAutoStart.Name = "ckbAutoStart";
            this.ckbAutoStart.Size = new System.Drawing.Size(146, 17);
            this.ckbAutoStart.TabIndex = 19;
            this.ckbAutoStart.Text = "Khởi động cùng windows";
            this.ckbAutoStart.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(19, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 314);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.radioButton4);
            this.tabPage1.Controls.Add(this.txtFolderDownload);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnSelectFolder);
            this.tabPage1.Controls.Add(this.radioButton3);
            this.tabPage1.Controls.Add(this.nudMaxProcessDownload);
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(678, 288);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cấu hình tải";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(152, 136);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(181, 17);
            this.radioButton4.TabIndex = 18;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Tách mỗi chapter là 1 file nén zip";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSelectFolder.ForeColor = System.Drawing.Color.Black;
            this.btnSelectFolder.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSelectFolder.IconColor = System.Drawing.Color.Black;
            this.btnSelectFolder.IconSize = 16;
            this.btnSelectFolder.Location = new System.Drawing.Point(569, 41);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Rotation = 0D;
            this.btnSelectFolder.Size = new System.Drawing.Size(99, 22);
            this.btnSelectFolder.TabIndex = 10;
            this.btnSelectFolder.Text = "Chọn thư mục";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtWebs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(678, 288);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nguồn truyện";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.radioButton8);
            this.tabPage3.Controls.Add(this.radioButton7);
            this.tabPage3.Controls.Add(this.radioButton6);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.radioButton5);
            this.tabPage3.Controls.Add(this.ckbOffAlert);
            this.tabPage3.Controls.Add(this.ckbAutoStart);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(678, 288);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tùy chọn";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Khởi động";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Thông báo";
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(148, 134);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(96, 17);
            this.radioButton8.TabIndex = 25;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Sleep máy tính";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(148, 111);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(85, 17);
            this.radioButton7.TabIndex = 24;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Tắt máy tính";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(148, 88);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(65, 17);
            this.radioButton6.TabIndex = 23;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Tự thoát";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Hành động khi tải xong";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(148, 65);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(86, 17);
            this.radioButton5.TabIndex = 21;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Không làm gì";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSaveSetting.ForeColor = System.Drawing.Color.Green;
            this.btnSaveSetting.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnSaveSetting.IconColor = System.Drawing.Color.Green;
            this.btnSaveSetting.IconSize = 16;
            this.btnSaveSetting.Location = new System.Drawing.Point(320, 332);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Rotation = 0D;
            this.btnSaveSetting.Size = new System.Drawing.Size(113, 23);
            this.btnSaveSetting.TabIndex = 2;
            this.btnSaveSetting.Text = "Lưu cấu hình";
            this.btnSaveSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(717, 362);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSaveSetting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSetting";
            this.Text = "Cấu hình";
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxProcessDownload)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtWebs;
        private FontAwesome.Sharp.IconButton btnSaveSetting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnSelectFolder;
        private System.Windows.Forms.TextBox txtFolderDownload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox ckbOffAlert;
        private System.Windows.Forms.NumericUpDown nudMaxProcessDownload;
        private System.Windows.Forms.CheckBox ckbAutoStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}