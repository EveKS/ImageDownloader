using AngleSharp.Parser.Html;
using ImageDownloader.Service.Telegram;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader.Service.Http
{
    class HttpService : IHttpService
    {
        ITelegramService _telegramService;

        public HttpService()
        {
            _telegramService = new TelegramService();
        }

        async Task<bool> IHttpService.DownloadFileAsync(string fileUrl, string path, string name)
        {
            bool isLoad = false;

            try
            {
                using (var client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(fileUrl))
                using (HttpContent content = response.Content)
                using (FileStream file = System.IO.File.Create($"{path}\\{name}"))
                {
                    await content.CopyToAsync(file);
                }

                isLoad = true;
            }
            catch (Exception ex)
            {
                await _telegramService.SendMessage($"program: ImageDownloader\nclass: HttpService\nmethod: DownloadFileAsync\nexception: {ex}");
            }

            return isLoad;
        }

        async Task<string> IHttpService.HttpGetStringContentAsync(string url)
        {
            var responseString = string.Empty;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "ISO-8859-1");

                    using (HttpResponseMessage response = await httpClient.GetAsync(new Uri(url)))
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                    using (var streamReader = new StreamReader(decompressedStream))
                    {
                        responseString = await streamReader.ReadToEndAsync();
                    }

                    //using (HttpContent content = response.Content)
                    //{
                    //    responseString = await content.ReadAsStringAsync();
                    //}
                    //    var bytes = await response.Content.ReadAsByteArrayAsync();

                    //    Encoding encoding = Encoding.GetEncoding("utf-8");
                    //    responseString = encoding.GetString(bytes, 0, bytes.Length);
                    //}
                }
            }
            catch (Exception ex)
            {
                await _telegramService.SendMessage($"program: ImageDownloader\nclass: HttpService\nmethod: HttpGetStringContentAsync\nexception: {ex}");
            }

            return responseString;
        }

        async Task<List<string>> IHttpService.ParseHtmlToJsonAsync(string content)
        {
            var containers = new List<string>(100);
            try
            {
                var parser = new HtmlParser();
                var document = parser.Parse(content);

                var imgContainers = "div[class='rg_meta notranslate']";
                containers = document.QuerySelectorAll(imgContainers)
                    .Select(doc => doc.TextContent)
                    .ToList();
            }
            catch (Exception ex)
            {
                await _telegramService.SendMessage($"program: ImageDownloader\nclass: HttpService\nmethod: ParseHtmlToUrlAsync\nexception: {ex}");
            }

            return containers;
        }
    }
}
