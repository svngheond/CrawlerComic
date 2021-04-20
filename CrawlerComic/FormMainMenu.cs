using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CrawlerComic.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using HtmlAgilityPack;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using PdfSharp.Pdf.IO;
using Ionic.Zip;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Deployment.Application;
using System.Reflection;
using Microsoft.Win32;

namespace CrawlerComic
{
    public partial class FormMainMenu : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private FormSearch formSearch;
        private List<ItemDownload> currentProcessDownloading = new List<ItemDownload>();
        private bool downloading = false;

        //Constructor
        public FormMainMenu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {     
                Version myVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                lbVersion.Text = string.Concat("v", myVersion);
                if (ApplicationDeployment.CurrentDeployment.IsFirstRun)
                {
                    try
                    {
                        string assemblyTitle = "";

                        object[] titleAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), true);
                        if (titleAttributes.Length > 0 && titleAttributes[0] is AssemblyTitleAttribute)
                        {
                            assemblyTitle = (titleAttributes[0] as AssemblyTitleAttribute).Title;
                        }

                        string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "comics.ico");
                        if (!File.Exists(iconSourcePath))
                        {
                            return;
                        }

                        RegistryKey myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                        string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                        for (int i = 0; i < mySubKeyNames.Length; i++)
                        {
                            RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                            object myValue = myKey.GetValue("DisplayName");
                            if (myValue != null && myValue.ToString() == assemblyTitle)
                            {
                                myKey.SetValue("DisplayIcon", iconSourcePath);
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

            //Load cấu hình
            string configStr = File.ReadAllText("config.json", Encoding.UTF8);
            var config = JsonConvert.DeserializeObject<Config>(configStr);
            DataForm.WebComics = config.WebComics;
            DataForm.MaxProcessDownload = config.MaxProcessDownload;
            DataForm.DownloadType = config.DownloadType;
            DataForm.Action = config.Action;
            DataForm.FolderDownload = string.IsNullOrEmpty(config.FolderDownload) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : config.FolderDownload;
            DataForm.OffAlert = config.OffAlert;
            DataForm.IsPause = false;

            //Load danh sách tải
            string downloadListStr = File.Exists("downloadlist.json") ? File.ReadAllText("downloadlist.json", Encoding.UTF8) : null;
            DataDownload.ListDownload = string.IsNullOrEmpty(downloadListStr) ? new List<ItemDownload>() : JsonConvert.DeserializeObject<List<ItemDownload>>(downloadListStr);

            //Open default form Search
            formSearch = new FormSearch();
            if (DataDownload.ListDownload.Where(x => x.Status != "Đã xong").Any())
            {
                ActivateButton(btnOrder, RGBColors.color2);
                OpenChildForm(new FormDownloading());
            }
            else
            {
                ActivateButton(btnDashboard, RGBColors.color1);
                OpenChildForm(formSearch);
            }

            //Start Download
            timer1.Start();
        }

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        public void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null && currentChildForm.Name != "FormSearch")
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            if (currentChildForm != null && currentChildForm.Name == "FormSearch")
            {
                ((FormSearch)currentChildForm).FormParent = this;
            }
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }
        //Events
        //Reset
        private void btnHome_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://doninhtatdiep.com");
        }
        //Menu Button_Clicks
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(formSearch);
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormDownload());
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormDownloading());
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormDownloaded());
        }
        private void btnMarketing_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            //OpenChildForm(new FormMarketing());
        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormSetting());
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Close-Maximize-Minimize
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        //Remove transparent border in maximized state
        private void FormMainMenu_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var downloads = DataDownload.ListDownload.Where(x => x.Status == "Chờ tải" && !currentProcessDownloading.Contains(x));
            if (downloads.Any())
            {
                if (!DataForm.IsPause && currentProcessDownloading.Count < DataForm.MaxProcessDownload)
                {
                    //Tải từng chapter
                    ItemDownload itemDownload = downloads.FirstOrDefault();
                    currentProcessDownloading.Add(itemDownload);
                    Thread t = null;
                    switch (DataForm.DownloadType)
                    {
                        case DownloadTypeEnum.MutilChapterOneFilePdf:
                        case DownloadTypeEnum.OneChapterOneFilePdf:
                            t = new Thread(() => RunDownloadPdf(itemDownload));
                            break;
                        case DownloadTypeEnum.OneChapterOneFolderImage:
                            t = new Thread(() => RunDownloadImage(itemDownload));
                            break;
                        case DownloadTypeEnum.OneChapterOneFileZip:
                            t = new Thread(() => RunDownloadZip(itemDownload));
                            break;
                    }
                    t.Start();
                    DataForm.Threads.Add(t);
                    downloading = true;
                }
            }
            else if (downloading)
            {
                bool isAlive = false;
                for (int i = 0, n = DataForm.Threads.Count; i < n; i++)
                {
                    if (DataForm.Threads[i].IsAlive)
                    {
                        isAlive = true;
                        break;
                    }
                }
                if (!isAlive)
                {
                    downloading = false;
                    bool openedAlert = Common.Alert("Đã tải xong toàn bộ", "", AlertTypeEnum.Success);
                    switch (DataForm.Action)
                    {
                        case ActionEnum.Nothing:
                            break;
                        case ActionEnum.Exit:
                            while (openedAlert)
                            {
                                openedAlert = false;
                                DataForm.Action = ActionEnum.Nothing;
                                Application.Exit();
                            }
                            break;
                        case ActionEnum.Shutdown:
                            SaveSettings();
                            while (openedAlert)
                            {
                                openedAlert = false;
                                DataForm.Action = ActionEnum.Nothing;
                                Process.Start("shutdown.exe", "-s -t 00");
                            }
                            break;
                        case ActionEnum.Sleep:
                            SaveSettings();
                            while (openedAlert)
                            {
                                openedAlert = false;
                                DataForm.Action = ActionEnum.Nothing;
                                Process.Start("RUNDLL32.EXE", "powrprof.dll,SetSuspendState 0,1,0");
                            }
                            break;
                    }
                }
            }
        }

        private void FormMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        #region Function
        private void RunDownloadPdf(ItemDownload itemDownload)
        {
            //Tạo folder chapter
            string folderChapterPath = DataForm.FolderDownload + @"\" + itemDownload.ComicName;
            if (!Directory.Exists(folderChapterPath))
                Directory.CreateDirectory(folderChapterPath);

            //Tải image
            UpdateStatus(itemDownload.ComicName, itemDownload.ChapterName, "Đang tải");
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb docHFile = new HtmlWeb();
            //html = docHFile.Load(itemDownload.ComicLink);
            html = docHFile.LoadFromWebAsync(itemDownload.ComicLink).Result;
            WebComic webComic = DataForm.WebComics.Where(x => itemDownload.ComicLink.Contains(x.web)).FirstOrDefault();
            HtmlNodeCollection nodes = html.DocumentNode.SelectNodes(webComic.pageChapterXpath);
            if (nodes != null)
            {
                string imageLink;
                PdfDocument doc = new PdfDocument();
                if (DataForm.DownloadType == DownloadTypeEnum.MutilChapterOneFilePdf)
                    doc.Info.Title = itemDownload.ChapterName;
                else if (DataForm.DownloadType == DownloadTypeEnum.OneChapterOneFilePdf)
                    doc.Info.Title = itemDownload.ComicName + "-" + itemDownload.ChapterName;

                doc.PageLayout = PdfPageLayout.SinglePage;

                for (int i = 0, n = nodes.Count; i < n; i++)
                {
                    imageLink = nodes[i].Attributes["src"].Value;
                    Image imagePageChapter = Common.DownloadImage(imageLink, webComic.headersDownloadImage);
                    if (imagePageChapter != null)
                    {
                        PdfPage pdfPage = new PdfPage();
                        XSize size = PageSizeConverter.ToSize(PageSize.A4);
                        XImage img = null;
                        if (imagePageChapter.Width > imagePageChapter.Height)
                        {
                            pdfPage.Orientation = PageOrientation.Landscape;
                            Image _imagePageChapter = ResizeImage(imagePageChapter, (int)size.Height, (int)size.Width - 5, false);
                            img = XImage.FromStream(GetStream(_imagePageChapter, ImageFormat.Jpeg));
                        }
                        else
                        {
                            pdfPage.Orientation = PageOrientation.Portrait;
                            Image _imagePageChapter = ResizeImage(imagePageChapter, (int)size.Width, (int)size.Height - 5, false);
                            img = XImage.FromStream(GetStream(_imagePageChapter, ImageFormat.Jpeg));
                        }

                        pdfPage.Width = size.Width * 72 / 96;
                        pdfPage.Height = size.Height * 72 / 96;

                        doc.Pages.Add(pdfPage);

                        XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[doc.Pages.Count - 1]);

                        double dx = xgr.PageSize.Width;
                        double dy = xgr.PageSize.Height;
                        xgr.DrawImage(img, (dx - (img.PixelWidth * 72) / 96) / 2, 0);
                    }
                }
                if (doc.Pages.Count == 0)
                {
                    UpdateStatus(itemDownload.ComicName, itemDownload.ChapterName, "Lỗi tải ảnh");
                    currentProcessDownloading.Remove(itemDownload);
                    ShowNotification("Lỗi tải ảnh: " + itemDownload.ComicName + "-" + itemDownload.ChapterName, "", AlertTypeEnum.Error);
                    return;
                }
                doc.Save(folderChapterPath + @"\" + itemDownload.ChapterName + ".pdf");
                doc.Close();
            }

            //Save file
            UpdateStatus(itemDownload.ComicName, itemDownload.ChapterName, "Đã xong");
            currentProcessDownloading.Remove(itemDownload);

            //Merge chapter pdf
            if (!DataDownload.ListDownload.Where(x => x.ComicName.Equals(itemDownload.ComicName) && !x.Status.Equals("Đã xong") && !x.Status.Equals("Lỗi tải ảnh")).Any())
            {
                if (DataForm.DownloadType == DownloadTypeEnum.MutilChapterOneFilePdf)
                {
                    string[] pdfChapters = Directory.GetFiles(folderChapterPath).Where(s => Path.GetExtension(s).ToLowerInvariant() == ".pdf").ToArray();
                    if (pdfChapters==null || pdfChapters.Count()==0)
                    {
                        ShowNotification("Không tải thành công chapter nào!", folderChapterPath,AlertTypeEnum.Error);
                        return;
                    }
                    MergeMultiplePDFIntoSinglePDF(folderChapterPath + "\\" + itemDownload.ComicName + ".pdf", pdfChapters, itemDownload.ComicName);
                }

                //Show notification
                if (!DataForm.OffAlert)
                    ShowNotification("Đã tải xong: " + itemDownload.ComicName, folderChapterPath);
            }
        }
        private void RunDownloadImage(ItemDownload itemDownload)
        {
            //Tạo folder chapter
            string folderChapterPath = DataForm.FolderDownload + @"\" + itemDownload.ComicName;
            if (!Directory.Exists(folderChapterPath))
                Directory.CreateDirectory(folderChapterPath);

            //Tải image
            UpdateStatus(itemDownload.ComicName, itemDownload.ChapterName, "Đang tải");
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb docHFile = new HtmlWeb();
            html = docHFile.Load(itemDownload.ComicLink);
            WebComic webComic = DataForm.WebComics.Where(x => itemDownload.ComicLink.Contains(x.web)).FirstOrDefault();
            HtmlNodeCollection nodes = html.DocumentNode.SelectNodes(webComic.pageChapterXpath);
            if (nodes != null)
            {
                string imageLink;
                for (int i = 0, n = nodes.Count; i < n; i++)
                {
                    imageLink = nodes[i].Attributes["src"].Value;
                    Image imagePageChapter = Common.DownloadImage(imageLink, webComic.headersDownloadImage);
                    if (imagePageChapter != null)
                    {
                        string imageType = imageLink.Split('.').Last();
                        imagePageChapter.Save(folderChapterPath + @"\" + Common.ToSafeFileName(nodes[i].Attributes["alt"].Value) + "." + imageType);
                    }
                }
            }

            //Save file
            UpdateStatus(itemDownload.ComicName, itemDownload.ChapterName, "Đã xong");
            currentProcessDownloading.Remove(itemDownload);

            //Show notification
            if (!DataForm.OffAlert && !DataDownload.ListDownload.Where(x => x.ComicName.Equals(itemDownload.ComicName) && !x.Status.Equals("Đã xong") && !x.Status.Equals("Lỗi tải ảnh")).Any())
                ShowNotification("Đã tải xong: " + itemDownload.ComicName, folderChapterPath);
        }
        private void RunDownloadZip(ItemDownload itemDownload)
        {
            //Tạo folder chapter
            string folderChapterPath = DataForm.FolderDownload + @"\" + itemDownload.ComicName + @"\" + itemDownload.ChapterName;
            if (!Directory.Exists(folderChapterPath))
                Directory.CreateDirectory(folderChapterPath);

            //Tải image
            UpdateStatus(itemDownload.ComicName, itemDownload.ChapterName, "Đang tải");
            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb docHFile = new HtmlWeb();
            html = docHFile.Load(itemDownload.ComicLink);
            WebComic webComic = DataForm.WebComics.Where(x => itemDownload.ComicLink.Contains(x.web)).FirstOrDefault();
            HtmlNodeCollection nodes = html.DocumentNode.SelectNodes(webComic.pageChapterXpath);
            if (nodes != null)
            {
                string imageLink, imageType, imagePath;
                for (int i = 0, n = nodes.Count; i < n; i++)
                {
                    imageLink = nodes[i].Attributes["src"].Value;
                    Image imagePageChapter = Common.DownloadImage(imageLink, webComic.headersDownloadImage);
                    if (imagePageChapter != null)
                    {
                        imageType = imageLink.Split('.').Last();
                        imagePath = folderChapterPath + @"\" + Common.ToSafeFileName(nodes[i].Attributes["alt"].Value) + "." + imageType;
                        imagePageChapter.Save(imagePath);
                    }
                }
                ZipMultipleImage(DataForm.FolderDownload + @"\" + itemDownload.ComicName + "\\" + itemDownload.ChapterName + ".zip", folderChapterPath);
            }

            //Save file
            UpdateStatus(itemDownload.ComicName, itemDownload.ChapterName, "Đã xong");
            currentProcessDownloading.Remove(itemDownload);

            //Show notification
            if (!DataForm.OffAlert && !DataDownload.ListDownload.Where(x => x.ComicName.Equals(itemDownload.ComicName) && !x.Status.Equals("Đã xong") && !x.Status.Equals("Lỗi tải ảnh")).Any())
                ShowNotification("Đã tải xong: " + itemDownload.ComicName, folderChapterPath);
        }

        private void MergeMultiplePDFIntoSinglePDF(string outputFilePath, string[] pdfFiles, string rootMenu)
        {
            pdfFiles = pdfFiles.OrderBy(x => int.Parse(x.Split('\\').Last().Split(' ').Last().Split('.').First())).ToArray();
            PdfDocument document = new PdfDocument();
            document.Info.Title = rootMenu;
            PdfOutline outline = null;
            for (int i = 0, n = pdfFiles.Length; i < n; i++)
            {
                try
                {
                    PdfDocument inputPDFDocument = PdfReader.Open(pdfFiles[i], PdfDocumentOpenMode.Import);
                    document.Version = inputPDFDocument.Version;
                    for (int j = 0, m = inputPDFDocument.Pages.Count; j < m; j++)
                    {
                        document.AddPage(inputPDFDocument.Pages[j]);
                        if (j == 0)
                        {
                            if (i == 0)
                                outline = document.Outlines.Add(rootMenu, document.Pages[j], true, PdfOutlineStyle.Bold, XColors.Red);
                            outline.Outlines.Add(inputPDFDocument.Info.Title, document.Pages[document.Pages.Count - 1], true);
                        }
                    }

                    // When document is add in pdf document remove file from folder  
                    File.Delete(pdfFiles[i]);
                }
                catch (Exception)
                {
                }
            }

            // Set font for paging  
            XFont font = new XFont("Verdana", 9);
            XBrush brush = XBrushes.Black;
            // Create variable that store page count  
            int noPages = document.Pages.Count;
            // Set for loop of document page count and set page number using DrawString function of PdfSharp  
            for (int i = 0; i < noPages; ++i)
            {
                PdfPage page = document.Pages[i];
                // Make a layout rectangle.  
                XRect layoutRectangle = new XRect(240 /*X*/ , page.Height - font.Height /*Y*/ , page.Width /*Width*/ , font.Height /*Height*/ );
                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    gfx.DrawString("Tải bởi CrawlerComic - Trang " + (i + 1).ToString() + " trên " + noPages, font, brush, layoutRectangle, XStringFormats.CenterLeft);
                }
            }
            document.Options.CompressContentStreams = true;
            document.Options.NoCompression = false;
            // In the final stage, all documents are merged and save in your output file path.  
            document.Save(outputFilePath);
        }
        private void ZipMultipleImage(string outputFilePath, string sourceFolderPath)
        {
            //Zip image
            string[] imagePages = Directory.GetFiles(sourceFolderPath).Where(s => Path.GetExtension(s).ToLowerInvariant() == ".jpg").ToArray();
            using (ZipFile zip = new ZipFile())
            {
                for (int i = 0, n = imagePages.Length; i < n; i++)
                {
                    FileStream page = File.OpenRead(imagePages[i]);
                    zip.AddEntry(Path.GetFileName(imagePages[i]), page);
                }
                zip.Save(outputFilePath);
            }
            //Delete file image
            Directory.Delete(sourceFolderPath, true);
        }

        private Stream GetStream(Image img, ImageFormat format)
        {
            var ms = new MemoryStream();
            img.Save(ms, format);
            return ms;
        }
        private Image ResizeImage(Image image, int newWidth, int maxHeight, bool onlyResizeIfWider)
        {
            if (onlyResizeIfWider && image.Width <= newWidth) newWidth = image.Width;

            var newHeight = image.Height * newWidth / image.Width;
            if (newHeight > maxHeight)
            {
                // Resize with height instead  
                newWidth = image.Width * maxHeight / image.Height;
                newHeight = maxHeight;
            }

            var res = new Bitmap(newWidth, newHeight);

            using (var graphic = Graphics.FromImage(res))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return res;
        }

        private void UpdateStatus(string comicName, string chapterName, string status)
        {
            var row = DataDownload.ListDownload.Where(x => x.ComicName == comicName && x.ChapterName == chapterName);
            if (row.Any())
            {
                row.FirstOrDefault().Status = status;
                Invoke(new Action(() =>
                {
                    //Cập nhật form ds tải
                    var formDownloading = Application.OpenForms.Cast<Form>().Where(form => form.Name == "FormDownload");
                    if (formDownloading.Any())
                    {
                        DataGridView grvComic = (DataGridView)formDownloading.FirstOrDefault().Controls.Find("grvComic", true).FirstOrDefault();
                        grvComic.DataSource = DataDownload.ListDownload;
                        grvComic.Refresh();
                    }

                    //Cập nhật form ds đang tải
                    formDownloading = Application.OpenForms.Cast<Form>().Where(form => form.Name == "FormDownloading");
                    if (formDownloading.Any())
                    {
                        DataGridView grvComic = (DataGridView)formDownloading.FirstOrDefault().Controls.Find("grvComic", true).FirstOrDefault();
                        grvComic.DataSource = null;
                        grvComic.DataSource = DataDownload.ListDownload.Where(x => !x.Status.Equals("Đã xong") && !x.Status.Equals("Lỗi tải ảnh")).ToList();
                    }

                    //Cập nhật form ds đã tải
                    formDownloading = Application.OpenForms.Cast<Form>().Where(form => form.Name == "FormDownloaded");
                    if (formDownloading.Any())
                    {
                        DataGridView grvComic = (DataGridView)formDownloading.FirstOrDefault().Controls.Find("grvComic", true).FirstOrDefault();
                        grvComic.DataSource = null;
                        grvComic.DataSource = DataDownload.ListDownload.Where(x => x.Status.Equals("Đã xong") || x.Status.Equals("Lỗi tải ảnh")).ToList();
                    }
                }));
            }
        }

        private void ShowNotification(string content, string folderPath, AlertTypeEnum alertTypeEnum = AlertTypeEnum.Success)
        {
            Invoke(new Action(() =>
            {
                Common.Alert(content, folderPath, alertTypeEnum);
            }));
        }

        private void SaveSettings()
        {
            DataDownload.ListDownload.ForEach(c => c.Status = (c.Status != "Đã xong" && c.Status != "Lỗi tải ảnh" ? "Chờ tải" : c.Status));
            Config config = new Config()
            {
                MaxProcessDownload = DataForm.MaxProcessDownload,
                DownloadType = DataForm.DownloadType,
                WebComics = DataForm.WebComics,
                FolderDownload = DataForm.FolderDownload,
                Action = DataForm.Action,
                OffAlert = DataForm.OffAlert
            };
            //Save setting
            JToken parsedJsonSetting = JToken.Parse(JsonConvert.SerializeObject(config));
            File.WriteAllText("config.json", parsedJsonSetting.ToString(Formatting.Indented));

            //Save download list
            JToken parsedJsonDownload = JToken.Parse(JsonConvert.SerializeObject(DataDownload.ListDownload));
            File.WriteAllText("downloadlist.json", parsedJsonDownload.ToString(Formatting.Indented));
        }
        #endregion
    }
}
