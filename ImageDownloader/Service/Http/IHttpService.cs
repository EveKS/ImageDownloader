using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageDownloader.Service.Http
{
    public interface IHttpService
    {
        Task<bool> DownloadFileAsync(string fileUrl, string path, string name);
        Task<string> HttpGetStringContentAsync(string url);
        Task<List<string>> ParseHtmlToJsonAsync(string content);
    }
}