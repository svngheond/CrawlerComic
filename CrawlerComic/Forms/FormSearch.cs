using CrawlerComic.Properties;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawlerComic.Forms
{
    public partial class FormSearch : Form
    {
        private WebComic currentWeb;
        private List<Comic> comics;
        public FormMainMenu FormParent { get; set; }
        public FormSearch()
        {
            InitializeComponent();

            //Bind data combox list web truyện
            cbSource.DataSource = DataForm.WebComics.Select(x => x.web).ToArray();

            //Design gridview
            DesignGridviewComic();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKeyword.Text))
            {
                //txtKeyword.Text = "Từ khóa...";
                txtKeyword.ForeColor = SystemColors.ButtonShadow;
            }
        }

        private void txtKeyword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtKeyword.Text == "Từ khóa...")
            {
                txtKeyword.Text = "";
                txtKeyword.ForeColor = SystemColors.WindowText;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtKeyword.Text))
                return;
            Thread t = new Thread(() => SearchComic());
            t.Start();
            //SearchComic();
        }

        private void DesignGridviewComic()
        {
            grvComic.AutoGenerateColumns = false;

            grvComic.Columns.Add("TT", "TT");
            grvComic.Columns[0].Width = 30;
            grvComic.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            grvComic.Columns.Add("TenTruyen", "Tên truyện");
            grvComic.Columns[1].Width = 400;
            grvComic.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grvComic.Columns[1].DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleLeft };

            DataGridViewImageColumn colAnhBia = new DataGridViewImageColumn();
            colAnhBia.HeaderText = "Ảnh bìa";
            colAnhBia.Image = null;
            colAnhBia.Name = "AnhBia";
            colAnhBia.ImageLayout = DataGridViewImageCellLayout.Stretch;
            grvComic.Columns.Add(colAnhBia);
            grvComic.Columns[2].Width = 80;
            grvComic.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            grvComic.Columns.Add("LuotDoc", "Lượt đọc");
            grvComic.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            grvComic.Columns.Add("ChapterMoi", "Chapter mới");
            grvComic.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewImageColumn colDownload = new DataGridViewImageColumn();
            colDownload.HeaderText = "Tải xuống";
            colDownload.Name = "TaiXuong";
            colDownload.Image = Resources.download;
            colDownload.Width = 60;
            grvComic.Columns.Add(colDownload);
            grvComic.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            grvComic.Columns["TT"].DataPropertyName = "TT";
            grvComic.Columns["TenTruyen"].DataPropertyName = "TenTruyen";
            grvComic.Columns["AnhBia"].DataPropertyName = "AnhBia";
            grvComic.Columns["LuotDoc"].DataPropertyName = "LuotDoc";
            grvComic.Columns["ChapterMoi"].DataPropertyName = "ChapterMoi";
        }
        private void SearchComic()
        {
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb docHFile = new HtmlWeb();
            html = docHFile.Load(currentWeb.linkSearch + txtKeyword.Text);
            HtmlNodeCollection nodes = html.DocumentNode.SelectNodes(currentWeb.resultSearchXpath);
            comics = new List<Comic>();
            if (nodes != null)
            {
                string tenTruyen, link, luotDoc, chapterMoi = string.Empty, linkChapterMoi = string.Empty, anhBia;
                Image imgAnhbia;
                HtmlNode nodeComic, nodeChapterMoi, nodeAnhBia;
                for (int i = 0, m = nodes.Count; i < m; i++)
                {
                    chapterMoi = string.Empty;
                    linkChapterMoi = string.Empty;
                    HtmlNode node = nodes[i];
                    nodeComic = nodes[i].SelectSingleNode(currentWeb.tenTruyenXpath);
                    if (nodeComic == null)
                    {
                        Common.Alert("Lỗi truy vấn tên truyện", "", AlertTypeEnum.Error);
                        break;
                    }
                    nodeChapterMoi = nodes[i].SelectSingleNode(currentWeb.chapterMoiXpath);
                    if (nodeChapterMoi != null)
                    {
                        chapterMoi = nodeChapterMoi.InnerText;
                        linkChapterMoi = nodeChapterMoi.Attributes["href"].Value;
                    }
                    tenTruyen = Common.ToSafeFileName(nodeComic.InnerText);
                    link = nodeComic.Attributes["href"].Value;
                    luotDoc = string.IsNullOrEmpty(currentWeb.luotDocXpath) ? "" : nodes[i].SelectSingleNode(currentWeb.luotDocXpath).InnerText;


                    nodeAnhBia = nodes[i].SelectSingleNode(currentWeb.anhBiaXpath);
                    anhBia = string.Empty;
                    if (nodeAnhBia.Attributes["data-original"] != null)
                        anhBia = nodeAnhBia.Attributes["data-original"].Value;
                    else if (nodeAnhBia.Attributes["data-src"] != null)
                        anhBia = nodeAnhBia.Attributes["data-src"].Value;
                    else
                        anhBia = nodeAnhBia.Attributes["src"].Value;

                    imgAnhbia = anhBia != string.Empty ? Common.DownloadImage(anhBia, currentWeb.headersDownloadImage) : null;
                    if (imgAnhbia == null)
                        imgAnhbia = global::CrawlerComic.Properties.Resources.No_Image_Available;
                    Comic comic = new Comic()
                    {
                        TT = i + 1,
                        TenTruyen = tenTruyen,
                        Link = link.IndexOf("http") > -1 ? link : currentWeb.web + link,
                        LuotDoc = luotDoc,
                        ChapterMoi = chapterMoi,
                        LinkChapterMoi = linkChapterMoi,
                        AnhBia = imgAnhbia
                    };
                    comics.Add(comic);
                }
            }
            Invoke(new Action(() =>
            {
                grvComic.DataSource = comics;
            }));
        }

        private void cbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentWeb = DataForm.WebComics[cbSource.SelectedIndex];
        }

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                SearchComic();
            }
        }

        private void grvComic_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && grvComic.Columns[e.ColumnIndex].Name == "TaiXuong")
            {
                grvComic.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Resources.spinner;
                if (MessageBox.Show("Ấn \"Yes\" để tải toàn bộ các chapter" + Environment.NewLine + "Ấn \"No\" để chọn lọc các chapter muốn tải", "Bạn có muốn tải toàn bộ các chapter xuống không?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //Add toàn bộ chapter vào hàng đợi download
                    List<Chapter> chapters = SearchChapter(comics[e.RowIndex].Link);
                    List<ItemDownload> downloads = new List<ItemDownload>();
                    for (int i = chapters.Count - 1; i >= 0; i--)
                    {
                        if (!Common.CheckExitsDownload(comics[e.RowIndex].TenTruyen, chapters[i].TenChuong))
                        {
                            downloads.Add(new ItemDownload()
                            {
                                ComicLink = chapters[i].Link,
                                LuotDoc = chapters[i].LuotDoc,
                                ComicName = comics[e.RowIndex].TenTruyen,
                                ChapterName = chapters[i].TenChuong,
                                Status = "Chờ tải"
                            });
                        }
                        else
                        {
                            DataDownload.ListDownload.Where(x => x.ComicName == comics[e.RowIndex].TenTruyen && x.ChapterName == chapters[i].TenChuong).FirstOrDefault().Status = "Chờ tải";
                        }
                    }
                    DataDownload.ListDownload.AddRange(downloads);
                }
                else
                {
                    //Mở form cho chọn chapter muốn tải
                    FormParent.OpenChildForm(new FormChapter(currentWeb, comics[e.RowIndex]));
                }
            }
        }

        private List<Chapter> SearchChapter(string comicFullLink)
        {
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb docHFile = new HtmlWeb();
            html = docHFile.Load(comicFullLink);
            HtmlNodeCollection nodes = html.DocumentNode.SelectNodes(currentWeb.listChapterXpath);
            List<Chapter> chapters = new List<Chapter>();
            if (nodes != null)
            {
                string tenTruyen, link, luotDoc, capNhat;
                HtmlNode nodeChapter, linkChapter;
                for (int i = 0, m = nodes.Count; i < m; i++)
                {
                    nodeChapter = nodes[i].SelectSingleNode(currentWeb.tenChuongXpath);

                    capNhat = string.IsNullOrEmpty(currentWeb.ngayCapNhatChuongXpath) ? "" : nodes[i].SelectSingleNode(currentWeb.ngayCapNhatChuongXpath).InnerText;
                    tenTruyen = Common.ToSafeFileName(nodeChapter.InnerText);
                    if (!string.IsNullOrEmpty(currentWeb.linkChuongXpath))
                    {
                        linkChapter = nodes[i].SelectSingleNode(currentWeb.linkChuongXpath);
                        link = linkChapter.Attributes["href"].Value.IndexOf("http") < 0 ? currentWeb.web + linkChapter.Attributes["href"].Value : linkChapter.Attributes["href"].Value;
                    }
                    else
                    {
                        link = nodeChapter.Attributes["href"].Value.IndexOf("http") < 0 ? currentWeb.web + nodeChapter.Attributes["href"].Value : nodeChapter.Attributes["href"].Value;
                    }
                    luotDoc = string.IsNullOrEmpty(currentWeb.luotXemChuongXpath) ? "" : nodes[i].SelectSingleNode(currentWeb.luotXemChuongXpath).InnerText;
                    Chapter chapter = new Chapter()
                    {
                        TenChuong = tenTruyen,
                        Link = link,
                        LuotDoc = luotDoc,
                        CapNhat = capNhat
                    };
                    chapters.Add(chapter);
                }
            }
            return chapters;
        }
    }
}