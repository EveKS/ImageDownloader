using ImageDownloader.Service.Telegram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageDownloader.Service.File
{
    class FileService : IFileService
    {
        static Random rnd = new Random();
        ITelegramService _telegramService;

        public FileService()
        {
            _telegramService = new TelegramService();
        }

        async Task<string> IFileService.CreateNameAsync(string extension, List<string> filesNames)
        {
            var fileName = string.Empty;
            try
            {
                var fileNameToChar = Enumerable.Range('a', 'z' - 'a')
                    .Select(Convert.ToChar)
                    .ToArray();

                while (filesNames.Contains(fileName = new string(fileNameToChar) + extension))
                {
                    NameGenerator(fileNameToChar);
                }
            }
            catch(Exception ex)
            {
                await _telegramService.SendMessage($"program: ImageDownloader\nclass: FileService\nmethod: CreateNameAsync\nexception: {ex}");
            }

            return fileName;
        }

        private void NameGenerator(IList<char> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                char temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
