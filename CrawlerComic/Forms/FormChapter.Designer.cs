namespace CrawlerComic.Forms
{
    partial class FormChapter
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.btnDownloadMulti = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grvComic = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvComic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnDownloadMulti);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 50);
            this.panel1.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.btnCancel.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.IconSize = 16;
            this.btnCancel.Location = new System.Drawing.Point(166, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Rotation = 0D;
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDownloadMulti
            // 
            this.btnDownloadMulti.BackColor = System.Drawing.Color.Gainsboro;
            this.btnDownloadMulti.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDownloadMulti.ForeColor = System.Drawing.Color.Green;
            this.btnDownloadMulti.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnDownloadMulti.IconColor = System.Drawing.Color.Green;
            this.btnDownloadMulti.IconSize = 16;
            this.btnDownloadMulti.Location = new System.Drawing.Point(12, 16);
            this.btnDownloadMulti.Name = "btnDownloadMulti";
            this.btnDownloadMulti.Rotation = 0D;
            this.btnDownloadMulti.Size = new System.Drawing.Size(148, 23);
            this.btnDownloadMulti.TabIndex = 0;
            this.btnDownloadMulti.Text = "Thêm vào danh sách tải";
            this.btnDownloadMulti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDownloadMulti.UseVisualStyleBackColor = false;
            this.btnDownloadMulti.Click += new System.EventHandler(this.btnDownloadMulti_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grvComic);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 400);
            this.panel2.TabIndex = 6;
            // 
            // grvComic
            // 
            this.grvComic.AllowUserToAddRows = false;
            this.grvComic.AllowUserToDeleteRows = false;
            this.grvComic.AllowUserToResizeColumns = false;
            this.grvComic.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.grvComic.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grvComic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvComic.BackgroundColor = System.Drawing.Color.White;
            this.grvComic.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvComic.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grvComic.ColumnHeadersHeight = 50;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvComic.DefaultCellStyle = dataGridViewCellStyle7;
            this.grvComic.GridColor = System.Drawing.Color.WhiteSmoke;
            this.grvComic.Location = new System.Drawing.Point(0, 0);
            this.grvComic.MultiSelect = false;
            this.grvComic.Name = "grvComic";
            this.grvComic.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvComic.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grvComic.RowHeadersVisible = false;
            this.grvComic.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grvComic.RowTemplate.DividerHeight = 1;
            this.grvComic.RowTemplate.Height = 120;
            this.grvComic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvComic.Size = new System.Drawing.Size(800, 400);
            this.grvComic.TabIndex = 0;
            this.grvComic.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvComic_CellClick);
            this.grvComic.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvComic_CellContentClick);
            // 
            // FormChapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChapter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn chương để tải về";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvComic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView grvComic;
        private FontAwesome.Sharp.IconButton btnDownloadMulti;
        private FontAwesome.Sharp.IconButton btnCancel;
    }
}