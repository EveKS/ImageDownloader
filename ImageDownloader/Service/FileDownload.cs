using ImageDownloader.JsonModel;
using ImageDownloader.Service.File;
using ImageDownloader.Service.Http;
using ImageDownloader.Service.JSON;
using ImageDownloader.Service.Telegram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader.Service
{
    class FileDownload : IFileDownload
    {
        IFileService _fileService;
        IHttpService _httpService;
        IJsonService _jsonService;
        ITelegramService _telegramService;

        public event EventHandler AppendText;
        public event EventHandler AppendTextToLB;

        public FileDownload()
        {
            _fileService = new FileService();
            _httpService = new HttpService();
            _jsonService = new JsonService();
            _telegramService = new TelegramService();
        }

        public bool IsMove(string directoriTo)
        {
            return string.IsNullOrEmpty(directoriTo);
        }

        public bool IsFolderExist(string directoryFrom)
        {
            try
            {
                bool isExist = Directory.Exists(directoryFrom);
                return isExist;
            }
            catch
            {
                return false;
            }
        }

        public async Task DownloadAsync(string queryString, string descriptionTo)
        {
            try
            {
                string url = "https://www.google.ru/search?q=" + queryString + "&tbm=isch&tbs=isz:l"; ;

                var getHtml = await _httpService.HttpGetStringContentAsync(url);
                if (!string.IsNullOrWhiteSpace(getHtml))
                {
                    var json = await _httpService.ParseHtmlToJsonAsync(getHtml);
                    var filesNames = new DirectoryInfo(descriptionTo)
                        .EnumerateFiles()
                        .Select(f => f.Name)
                        .ToList();

                    var count = json.Count;
                    AppendTextToLB($"Saved: {0} from {count}", EventArgs.Empty);

                    for (int i = 0; i < count; i++)
                    {
                        try
                        {
                            var extension = string.Empty;
                            var imageInfo = _jsonService.JsonConvertDeserializeObjectWithNull<ImageInfo>(json[i]);

                            if (imageInfo != null)
                            {
                                if (string.IsNullOrWhiteSpace(imageInfo.Extension))
                                {
                                    extension = Path.GetExtension(imageInfo.Path);
                                }
                                else
                                {
                                    extension = $".{imageInfo.Extension}";
                                }

                                var name = await _fileService.CreateNameAsync(extension, filesNames);

                                AppendText?.Invoke
                                    (string.Format("{0}\nBegin download file: {1}\nDomain: {2}\nTitle: {3}\nPage: {4}",
                                        new string('-', 10),
                                        name,
                                        imageInfo.Domain,
                                        imageInfo.PhotoTitle,
                                        imageInfo.Page
                                    ),
                                    EventArgs.Empty);

                                var isLoad = await _httpService
                                    .DownloadFileAsync(imageInfo.Path, descriptionTo, name);

                                if (isLoad)
                                {
                                    AppendText?.Invoke
                                        ($"\nFile {name} downloaded\n"
                                        , EventArgs.Empty);
                                    filesNames.Add(name);

                                    AppendTextToLB($"Saved: {i + 1} from {count}", EventArgs.Empty);
                                }
                                else
                                {
                                    AppendText?.Invoke
                                        ($"\nFile not downloaded\n"
                                        , EventArgs.Empty);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            AppendText?.Invoke
                                ($"\nFile not downloaded\n"
                                , EventArgs.Empty);
                            await _telegramService.SendMessage($"program: ImageDownloader\nclass: FileDownload\nmethod: DownloadAsync\nfile: {json[i]}\nexception: {ex}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await _telegramService.SendMessage($"program: ImageDownloader\nclass: FileDownload\nmethod: DownloadAsync\nexception: {ex}");
            }
        }
    }
}
