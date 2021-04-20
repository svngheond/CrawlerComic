using CrawlerComic.Properties;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawlerComic.Forms
{
    public partial class FormDownloading : Form
    {
        private List<Chapter> chapters;
        private WebComic currentWeb;
        private Comic currentComic;
        CheckBox headerCheckBox = new CheckBox();
        public FormDownloading()
        {
            InitializeComponent();

            //Design gridview
            DesignGridviewChapter();
            grvComic.DataSource = DataDownload.ListDownload.Where(x =>!x.Status.Equals("Đã xong") && !x.Status.Equals("Lỗi tải ảnh")).ToList();

            #region Add checkbox all on gridview
            //Add a CheckBox Column to the DataGridView Header Cell.
            //Find the Location of Header Cell.
            Point headerCellLocation = this.grvComic.GetCellDisplayRectangle(0, -1, true).Location;
            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 15);
            headerCheckBox.BackColor = Color.White;
            headerCheckBox.Size = new Size(18, 18);
            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            grvComic.Controls.Add(headerCheckBox);
            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "Chon";
            checkBoxColumn.TrueValue = true;
            checkBoxColumn.FalseValue = false;
            grvComic.Columns.Insert(0, checkBoxColumn);
            #endregion
        }

        private void DesignGridviewChapter()
        {
            grvComic.AutoGenerateColumns = false;

            grvComic.Columns.Add("ComicName", "Tên truyện");
            grvComic.Columns[0].Width = 300;
            grvComic.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grvComic.Columns[0].DefaultCellStyle = new DataGridViewCellStyle() { Alignment=DataGridViewContentAlignment.MiddleLeft};

            grvComic.Columns.Add("ChapterName", "Tên chương");
            grvComic.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            grvComic.Columns.Add("LuotDoc", "Lượt đọc");
            grvComic.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            grvComic.Columns.Add("Status", "Trạng thái");
            grvComic.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            grvComic.Columns["ComicName"].DataPropertyName = "ComicName";
            grvComic.Columns["ChapterName"].DataPropertyName = "ChapterName";
            grvComic.Columns["LuotDoc"].DataPropertyName = "LuotDoc";
            grvComic.Columns["Status"].DataPropertyName = "Status";
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            grvComic.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            foreach (DataGridViewRow row in grvComic.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["Chon"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
        }
        private void SearchChapter(string comicFullLink)
        {
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb docHFile = new HtmlWeb();
            html = docHFile.Load(comicFullLink);
            HtmlNodeCollection nodes = html.DocumentNode.SelectNodes(currentWeb.listChapterXpath);
            if (nodes != null)
            {
                chapters = new List<Chapter>();
                string tenTruyen, link, luotDoc, capNhat;
                HtmlNode nodeChapter;
                for (int i = 0, m = nodes.Count; i < m; i++)
                {
                    nodeChapter = nodes[i].SelectSingleNode(currentWeb.tenChuongXpath);
                    capNhat = nodes[i].SelectSingleNode(currentWeb.ngayCapNhatChuongXpath).InnerText;
                    tenTruyen = nodeChapter.InnerText;
                    link = nodeChapter.Attributes["href"].Value;
                    luotDoc = nodes[i].SelectSingleNode(currentWeb.luotXemChuongXpath).InnerText;
                    Chapter chapter = new Chapter()
                    {
                        TenChuong = tenTruyen,
                        Link = link,
                        LuotDoc = luotDoc,
                        CapNhat = capNhat
                    };
                    chapters.Add(chapter);
                }
                grvComic.DataSource = chapters;
            }
        }

        private void grvComic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                if (grvComic.Columns[e.ColumnIndex].Name == "TaiXuong")
                {
                    grvComic.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Resources.spinner;
                    //Tải từng chương
                    if (!Common.CheckExitsDownload(currentComic.TenTruyen, chapters[e.RowIndex].TenChuong))
                    {
                        DataDownload.ListDownload.Add(new ItemDownload()
                        {
                            ComicLink = chapters[e.RowIndex].Link,
                            LuotDoc = chapters[e.RowIndex].LuotDoc,
                            ComicName = currentComic.TenTruyen,
                            ChapterName = chapters[e.RowIndex].TenChuong
                        });
                    }
                    else
                    {
                        DataDownload.ListDownload.Where(x => x.ComicName == currentComic.TenTruyen && x.ChapterName == chapters[e.RowIndex].TenChuong).FirstOrDefault().Status = "Chờ tải";
                    }
                }
                else if (grvComic.Columns[e.ColumnIndex].Name == "Chon")
                {
                    object cellValue = grvComic.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (cellValue == null)
                        grvComic.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    grvComic.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)grvComic.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
            }
        }

        private void grvComic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in grvComic.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Chon"].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = isChecked;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bool flag = false;
            for (int i = grvComic.Rows.Count-1, n = 0; i >= n; i--)
            {
                if (Convert.ToBoolean(grvComic.Rows[i].Cells["Chon"].EditedFormattedValue) == true)
                {
                    DataDownload.ListDownload.Remove(DataDownload.ListDownload[i]);
                    flag = true;
                }
            }
            if (flag)
            {
                grvComic.DataSource = null;
                grvComic.DataSource = DataDownload.ListDownload;
            }
            else
            {
                MessageBox.Show("Bạn phải chọn các chapter muốn dừng tải!");
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            DataForm.IsPause = !DataForm.IsPause;
            if (DataForm.IsPause)
            {
                this.btnPause.ForeColor = System.Drawing.Color.Green;
                this.btnPause.IconChar = FontAwesome.Sharp.IconChar.Play;
                this.btnPause.IconColor = System.Drawing.Color.Green;
                btnPause.Text = "Tải tiếp";
            }
            else
            {
                this.btnPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.btnPause.IconChar = FontAwesome.Sharp.IconChar.Pause;
                this.btnPause.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                btnPause.Text = "Tạm dừng";
            }
        }

        private void btnReDownload_Click(object sender, EventArgs e)
        {
            bool flag = false;
            for (int i = grvComic.Rows.Count - 1, n = 0; i >= n; i--)
            {
                if (Convert.ToBoolean(grvComic.Rows[i].Cells["Chon"].EditedFormattedValue) == true)
                {
                    DataDownload.ListDownload[i].Status = "Chờ tải";
                    flag = true;
                }
            }
            if (flag)
            {
                grvComic.DataSource = null;
                grvComic.DataSource = DataDownload.ListDownload;
            }
            else
            {
                MessageBox.Show("Bạn phải chọn các chapter muốn tải lại!");
            }
        }
    }
}
