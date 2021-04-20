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
    public partial class FormChapter : Form
    {
        private List<Chapter> chapters;
        private WebComic currentWeb;
        private Comic currentComic;
        CheckBox headerCheckBox = new CheckBox();
        public FormChapter(WebComic _currentWeb, Comic _currentComic)
        {
            InitializeComponent();
            currentWeb = _currentWeb;
            currentComic = _currentComic;

            //Design gridview
            DesignGridviewChapter();
            SearchChapter(_currentComic.Link);

            //Add a CheckBox Column to the DataGridView Header Cell.
            //Find the Location of Header Cell.
            Point headerCellLocation = this.grvComic.GetCellDisplayRectangle(0, -1, true).Location;
            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
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
        }

        private void DesignGridviewChapter()
        {
            grvComic.AutoGenerateColumns = false;

            grvComic.Columns.Add("TenChuong", "Tên chương");
            grvComic.Columns[0].Width = 400;
            grvComic.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grvComic.Columns[0].DefaultCellStyle = new DataGridViewCellStyle() { Alignment=DataGridViewContentAlignment.MiddleLeft };

            grvComic.Columns.Add("CapNhat", "Cập nhật");
            grvComic.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            grvComic.Columns.Add("LuotDoc", "Lượt đọc");
            grvComic.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewImageColumn colDownload = new DataGridViewImageColumn();
            colDownload.HeaderText = "Tải xuống";
            colDownload.Name = "TaiXuong";
            colDownload.Image = Resources.download;
            colDownload.Width = 60;
            grvComic.Columns.Add(colDownload);
            grvComic.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            grvComic.Columns["TenChuong"].DataPropertyName = "TenChuong";
            grvComic.Columns["CapNhat"].DataPropertyName = "CapNhat";
            grvComic.Columns["LuotDoc"].DataPropertyName = "LuotDoc";
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
            //try
            //{
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
                        capNhat = string.IsNullOrEmpty(currentWeb.ngayCapNhatChuongXpath) ? "" : nodes[i].SelectSingleNode(currentWeb.ngayCapNhatChuongXpath).InnerText;
                        tenTruyen = nodeChapter.InnerText;
                        link = string.IsNullOrEmpty(currentWeb.linkChuongXpath)? nodeChapter.Attributes["href"].Value: nodes[i].SelectSingleNode(currentWeb.linkChuongXpath).Attributes["href"].Value;
                        luotDoc = string.IsNullOrEmpty(currentWeb.luotXemChuongXpath) ? "" : nodes[i].SelectSingleNode(currentWeb.luotXemChuongXpath).InnerText;
                        Chapter chapter = new Chapter()
                        {
                            TenChuong = tenTruyen,
                            Link = link.IndexOf("http")>-1? link:currentWeb.web+link,
                            LuotDoc = luotDoc,
                            CapNhat = capNhat
                        };
                        chapters.Add(chapter);
                    }
                    grvComic.DataSource = chapters;
                }
            //}
            //catch (Exception)
            //{
            //    DataForm.Alert("Có lỗi xảy ra", "", AlertTypeEnum.Error);
            //}
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
                            ChapterName = chapters[e.RowIndex].TenChuong,
                            Status = "Chờ tải"
                        });
                        this.Close();
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

        private void btnDownloadMulti_Click(object sender, EventArgs e)
        {
            List<ItemDownload> downloads = new List<ItemDownload>();
            for (int i = 0, n = grvComic.Rows.Count; i < n; i++)
            {
                if (Convert.ToBoolean(grvComic.Rows[i].Cells["Chon"].EditedFormattedValue) == true)
                {
                    if (!Common.CheckExitsDownload(currentComic.TenTruyen, chapters[i].TenChuong))
                    {
                        downloads.Add(new ItemDownload()
                        {
                            ComicLink = chapters[i].Link,
                            LuotDoc = chapters[i].LuotDoc,
                            ComicName = currentComic.TenTruyen,
                            ChapterName = chapters[i].TenChuong,
                            Status = "Chờ tải"
                        });
                    }
                    else
                    {
                        DataDownload.ListDownload.Where(x => x.ComicName == currentComic.TenTruyen && x.ChapterName == chapters[i].TenChuong).FirstOrDefault().Status = "Chờ tải";
                    }
                }
            }
            downloads = downloads.OrderBy(x => x.ComicName).ThenBy(x => int.Parse(x.ChapterName.Split(' ')[1])).ToList();
            DataDownload.ListDownload.AddRange(downloads);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
