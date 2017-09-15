using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace ImageDownloader.Service.Telegram
{
    class TelegramService : ITelegramService
    {
        const string TOKEN = "344652520:AAE6zsadftMdDgalmz2H3vEMq52eAR5bjag";

        async Task ITelegramService.SendMessageExceptionAsync(Exception ex)
        {
            await SendMessagePrivate(ex.ToString());
        }

        async Task ITelegramService.SendMessage(string message)
        {
            await SendMessagePrivate(message);
        }

        private async Task SendMessagePrivate(string text)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var url = "https://api.telegram.org/bot" + TOKEN +
                        "/sendMessage?";

                    using (var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("chat_id", "273841531"),
                        new KeyValuePair<string, string>("text", text)
                    }))
                    {
                        await httpClient.PostAsync(url, content);
                    }
                }
            }
            catch { }
        }
    }
}