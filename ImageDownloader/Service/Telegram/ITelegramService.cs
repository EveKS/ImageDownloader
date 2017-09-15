using System.Threading.Tasks;
using System;

namespace ImageDownloader.Service.Telegram
{
    public interface ITelegramService
    {
        Task SendMessage(string message);
        Task SendMessageExceptionAsync(Exception ex);
    }
}