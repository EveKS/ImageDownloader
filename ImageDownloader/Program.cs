using FileMoveTo;
using ImageDownloader.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDownloader
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Main form = new Main();
            IMessageService service = new MessageService();
            IFileDownload manager = new FileDownload();

            Manager presenter = new Manager(form, manager, service);

            Application.Run(form);
        }
    }
}
