using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageDownloader.Service.File
{
    public interface IFileService
    {
        Task<string> CreateNameAsync(string extension, List<string> filesNames);
    }
}