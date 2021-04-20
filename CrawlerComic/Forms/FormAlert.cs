using CrawlerComic.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrawlerComic
{
    public partial class FormAlert : Form
    {
        private string FolderDownloadedPath { get; set; }
        public FormAlert()
        {
            InitializeComponent();
        }

        private int x, y;
        public bool SetAlert(string msg, string folderPath, AlertTypeEnum type)
        {
            FolderDownloadedPath = folderPath;
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                FormAlert f = (FormAlert)Application.OpenForms[fname];

                if (f == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
            switch (type)
            {
                case AlertTypeEnum.Success:
                    this.GunaPictureBox1.Image = Resources.Checkmark_28px;
                    this.BackColor = Color.FromArgb(42, 171, 160);
                    break;
                case AlertTypeEnum.Warning:
                    this.GunaPictureBox1.Image = Resources.Warning_28px;
                    this.BackColor = Color.FromArgb(255, 179, 2);
                    break;
                case AlertTypeEnum.Error:
                    this.GunaPictureBox1.Image = Resources.Error_28px;
                    this.BackColor = Color.FromArgb(255, 121, 70);
                    break;
                case AlertTypeEnum.Info:
                    this.GunaPictureBox1.Image = Resources.Info_28px;
                    this.BackColor = Color.FromArgb(71, 169, 248);
                    break;
            }
            this.GunaLabel1.Text = msg;

            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Show();
            this.action = actionEnum.start;
            this.Timer1.Interval = 1;
            this.Timer1.Start();
            return true;
        }

        public enum actionEnum
        {
            wait,
            start,
            close
        }

        private FormAlert.actionEnum action;

       
        private void GunaPictureBox2_Click(object sender, EventArgs e)
        {
            this.Timer1.Interval = 1;
            this.action = FormAlert.actionEnum.close;
        }

        private void FormAlert_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FolderDownloadedPath))
                Process.Start(FolderDownloadedPath);
        }

        private void GunaPictureBox1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FolderDownloadedPath))
                Process.Start(FolderDownloadedPath);
        }

        private void GunaLabel1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FolderDownloadedPath))
                Process.Start(FolderDownloadedPath);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case FormAlert.actionEnum.wait:
                    this.Timer1.Interval = 5000;
                    this.action = FormAlert.actionEnum.close;
                    break;
                case FormAlert.actionEnum.start:
                    this.Timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            this.action = FormAlert.actionEnum.wait;
                        }
                    }
                    break;
                case FormAlert.actionEnum.close:
                    this.Timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

    }
}
