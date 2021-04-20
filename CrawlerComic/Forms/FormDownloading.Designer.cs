namespace CrawlerComic.Forms
{
    partial class FormDownloading
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReDownload = new FontAwesome.Sharp.IconButton();
            this.btnPause = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grvComic = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvComic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReDownload);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 50);
            this.panel1.TabIndex = 5;
            // 
            // btnReDownload
            // 
            this.btnReDownload.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnReDownload.ForeColor = System.Drawing.Color.Green;
            this.btnReDownload.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.btnReDownload.IconColor = System.Drawing.Color.Green;
            this.btnReDownload.IconSize = 16;
            this.btnReDownload.Location = new System.Drawing.Point(12, 12);
            this.btnReDownload.Name = "btnReDownload";
            this.btnReDownload.Rotation = 0D;
            this.btnReDownload.Size = new System.Drawing.Size(62, 23);
            this.btnReDownload.TabIndex = 3;
            this.btnReDownload.Text = "Tải lại";
            this.btnReDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReDownload.UseVisualStyleBackColor = true;
            this.btnReDownload.Click += new System.EventHandler(this.btnReDownload_Click);
            // 
            // btnPause
            // 
            this.btnPause.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPause.IconChar = FontAwesome.Sharp.IconChar.Pause;
            this.btnPause.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPause.IconSize = 16;
            this.btnPause.Location = new System.Drawing.Point(80, 12);
            this.btnPause.Name = "btnPause";
            this.btnPause.Rotation = 0D;
            this.btnPause.Size = new System.Drawing.Size(82, 23);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Tạm dừng";
            this.btnPause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.btnCancel.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.IconSize = 16;
            this.btnCancel.Location = new System.Drawing.Point(168, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Rotation = 0D;
            this.btnCancel.Size = new System.Drawing.Size(82, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy tải về";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.grvComic.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grvComic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvComic.BackgroundColor = System.Drawing.Color.White;
            this.grvComic.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvComic.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grvComic.ColumnHeadersHeight = 50;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvComic.DefaultCellStyle = dataGridViewCellStyle3;
            this.grvComic.GridColor = System.Drawing.Color.WhiteSmoke;
            this.grvComic.Location = new System.Drawing.Point(0, 0);
            this.grvComic.MultiSelect = false;
            this.grvComic.Name = "grvComic";
            this.grvComic.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvComic.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grvComic.RowHeadersVisible = false;
            this.grvComic.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grvComic.RowTemplate.DividerHeight = 1;
            this.grvComic.RowTemplate.Height = 30;
            this.grvComic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvComic.Size = new System.Drawing.Size(800, 400);
            this.grvComic.TabIndex = 0;
            this.grvComic.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvComic_CellClick);
            this.grvComic.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvComic_CellContentClick);
            // 
            // FormDownloading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDownloading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách đang tải về";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvComic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView grvComic;
        private FontAwesome.Sharp.IconButton btnCancel;
        private FontAwesome.Sharp.IconButton btnPause;
        private FontAwesome.Sharp.IconButton btnReDownload;
    }
}