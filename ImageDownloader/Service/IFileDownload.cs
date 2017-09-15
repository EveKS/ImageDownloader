using System;
using System.Threading.Tasks;

namespace ImageDownloader.Service
{
    interface IFileDownload
    {
        event EventHandler AppendText;
        event EventHandler AppendTextToLB;

        Task DownloadAsync(string queryString, string descriptionTo);
        bool IsFolderExist(string directoryFrom);
        bool IsMove(string directoriTo);
    }
}