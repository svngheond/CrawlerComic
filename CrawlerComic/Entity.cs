using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrawlerComic
{
    public class Config
    {
        public List<WebComic> WebComics { get; set; }
        public int MaxProcessDownload { get; set; }
        public DownloadTypeEnum DownloadType { get; set; }
        public ActionEnum Action { get; set; }
        public string FolderDownload { get; set; }
        public bool OffAlert { get; set; }
    }
    public class WebComic
    {
        public string web { get; set; }
        public string linkSearch { get; set; }
        public string resultSearchXpath { get; set; }
        public string tenTruyenXpath { get; set; }
        public string chapterMoiXpath { get; set; }
        public string luotDocXpath { get; set; }
        public string anhBiaXpath { get; set; }
        public string listChapterXpath { get; set; }
        public string linkChuongXpath { get; set; }
        public string tenChuongXpath { get; set; }
        public string ngayCapNhatChuongXpath { get; set; }
        public string luotXemChuongXpath { get; set; }
        public string pageChapterXpath { get; set; }
        public List<ItemHeader> headersDownloadImage { get; set; }
    }
    public class Comic
    {
        public int TT { get; set; }
        public string TenTruyen { get; set; }
        public Image AnhBia { get; set; }
        public string LuotDoc { get; set; }
        public string Link { get; set; }
        public string ChapterMoi { get; set; }
        public string LinkChapterMoi { get; set; }
    }
    public class Chapter
    {
        public string TenChuong { get; set; }
        public string CapNhat { get; set; }
        public string LuotDoc { get; set; }
        public string Link { get; set; }
    }
    public class ItemDownload
    {
        /// <summary>
        /// Tên truyện
        /// </summary>
        public string ComicName { get; set; }
        /// <summary>
        /// Tên chương
        /// </summary>
        public string ChapterName { get; set; }
        public string ComicLink { get; set; }
        public string LuotDoc { get; set; }
        public string Status { get; set; }
    }
    public class ItemHeader
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    public static class DataForm
    {
        public static List<WebComic> WebComics { get; set; }
        public static int MaxProcessDownload { get; set; }
        public static DownloadTypeEnum DownloadType { get; set; }
        public static ActionEnum Action { get; set; }
        public static bool IsPause { get; set; }
        public static bool OffAlert { get; set; }
        public static string FolderDownload { get; set; }
        public static List<Thread> Threads { get; set; } = new List<Thread>();
    }
    public static class DataDownload
    {
        public static List<ItemDownload> ListDownload { get; set; } = new List<ItemDownload>();
    }
    public static class Common
    {
        public static bool CheckExitsDownload(string comicName, string chapterName)
        {
            return DataDownload.ListDownload.Where(x => x.ComicName == comicName && x.ChapterName == chapterName).Any();
        }
        public static Image DownloadImage(string imageUrl, List<ItemHeader> itemHeaders)
        {
            try
            {
                if (imageUrl.IndexOf("http:") < 0)
                    imageUrl = "http:" + imageUrl;
                using (WebClient webClient = new WebClient())
                {
                    foreach (var item in itemHeaders)
                    {
                        webClient.Headers.Set(item.key, item.value);
                    }
                    using (Stream stream = webClient.OpenRead(imageUrl))
                    {
                        return Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static MemoryStream DownloadImageStream(string imageUrl, List<ItemHeader> itemHeaders)
        {
            MemoryStream imageStream = new MemoryStream();
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    foreach (var item in itemHeaders)
                    {
                        webClient.Headers.Set(item.key, item.value);
                    }
                    using (Stream stream = webClient.OpenRead(imageUrl))
                    {
                        stream.CopyTo(imageStream);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return imageStream;
        }
        public static bool Alert(string msg, string folderPath, AlertTypeEnum type)
        {
            FormAlert f = new FormAlert();
            return f.SetAlert(msg, folderPath, type);
        }
        public static string ToSafeFileName(string fileName)
        {
            return fileName
                .Replace("\\", "")
                .Replace("/", "")
                .Replace("\"", "")
                .Replace("*", "")
                .Replace(":", "")
                .Replace("?", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "");
        }
    }
    public enum DownloadTypeEnum
    {
        MutilChapterOneFilePdf,
        OneChapterOneFilePdf,
        OneChapterOneFolderImage,
        OneChapterOneFileZip
    }
    public enum ActionEnum
    {
        Nothing,
        Exit,
        Shutdown,
        Sleep
    }
    public enum AlertTypeEnum
    {
        Success,
        Warning,
        Error,
        Info
    }
}
