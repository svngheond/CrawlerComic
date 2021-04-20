using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawlerComic.Forms
{
    public partial class FormSetting : Form
    {
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public FormSetting()
        {
            InitializeComponent();
            nudMaxProcessDownload.Value = DataForm.MaxProcessDownload;
            JToken parsedJson = JToken.Parse(JsonConvert.SerializeObject(DataForm.WebComics));
            txtWebs.Text = parsedJson.ToString(Formatting.Indented);
            txtFolderDownload.Text = DataForm.FolderDownload;
            ckbOffAlert.Checked = DataForm.OffAlert;

            //Set download type
            if (DataForm.DownloadType == DownloadTypeEnum.MutilChapterOneFilePdf)
                radioButton1.Checked = true;
            else if (DataForm.DownloadType == DownloadTypeEnum.OneChapterOneFilePdf)
                radioButton2.Checked = true;
            else if (DataForm.DownloadType == DownloadTypeEnum.OneChapterOneFolderImage)
                radioButton3.Checked = true;
            else if (DataForm.DownloadType == DownloadTypeEnum.OneChapterOneFileZip)
                radioButton4.Checked = true;

            //Set action when downloaded
            if (DataForm.Action == ActionEnum.Nothing)
                radioButton5.Checked = true;
            else if (DataForm.Action == ActionEnum.Exit)
                radioButton6.Checked = true;
            else if (DataForm.Action == ActionEnum.Shutdown)
                radioButton7.Checked = true;
            else if (DataForm.Action == ActionEnum.Sleep)
                radioButton8.Checked = true;

            //Set auto start
            if (rkApp.GetValue("CrawlerComic") == null)
            {
                // The value doesn't exist, the application is not set to run at startup
                ckbAutoStart.Checked = false;
            }
            else
            {
                // The value exists, the application is set to run at startup
                ckbAutoStart.Checked = true;
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            DataForm.MaxProcessDownload = int.Parse(nudMaxProcessDownload.Value.ToString());
            DataForm.WebComics = JsonConvert.DeserializeObject<List<WebComic>>(txtWebs.Text);
            DataForm.FolderDownload = txtFolderDownload.Text;
            DataForm.OffAlert = ckbOffAlert.Checked;

            //Download type
            if (radioButton1.Checked)
                DataForm.DownloadType = DownloadTypeEnum.MutilChapterOneFilePdf;
            else if (radioButton2.Checked)
                DataForm.DownloadType = DownloadTypeEnum.OneChapterOneFilePdf;
            else if (radioButton3.Checked)
                DataForm.DownloadType = DownloadTypeEnum.OneChapterOneFolderImage;
            else if (radioButton4.Checked)
                DataForm.DownloadType = DownloadTypeEnum.OneChapterOneFileZip;

            //Action when downloaded
            if (radioButton5.Checked)
                DataForm.Action = ActionEnum.Nothing;
            else if (radioButton6.Checked)
                DataForm.Action = ActionEnum.Exit;
            else if (radioButton7.Checked)
                DataForm.Action = ActionEnum.Shutdown;
            else if (radioButton8.Checked)
                DataForm.Action = ActionEnum.Sleep;

            //Auto start
            if (ckbAutoStart.Checked)
            {
                // Add the value in the registry so that the application runs at startup
                rkApp.SetValue("CrawlerComic", Application.ExecutablePath);
            }
            else
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue("CrawlerComic", false);
            }

            Common.Alert("Đã lưu thành công","", AlertTypeEnum.Success);
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtFolderDownload.Text = folderBrowserDialog1.SelectedPath;
            }
        }

    }
}
