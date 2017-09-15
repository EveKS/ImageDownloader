using FileMoveTo;
using ImageDownloader.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageDownloader
{
    class Manager
    {
        private readonly IMainForm _view;
        private readonly IFileDownload _service;
        private readonly IMessageService _messegeService;

        public Manager(IMainForm view, IFileDownload service, IMessageService messegeService)
        {
            _view = view;
            _service = service;
            _messegeService = messegeService;

            _view.Download += _view_Download;
            _service.AppendText += _service_AppendText;
            _service.AppendTextToLB += _service_AppendTextToLB;
        }

        private void _service_AppendTextToLB(object sender, EventArgs e)
        {
            if (sender is string str)
            {
                _view.SetMessageToLable = str;
            }
        }

        private void _service_AppendText(object sender, EventArgs e)
        {
            if (sender is string str)
            {
                _view.SetMessageToRichTextBox = str;
            }
        }

        private async void _view_Download(object sender, EventArgs e)
        {
            try
            {
                string queryString = _view.QueryString;
                string directoriTo = _view.SelectToPath;

                bool isMove = _service.IsMove(directoriTo);

                if (isMove)
                {
                    _messegeService.ShowExclamation("Specify the path");
                    return;
                }

                bool isFolderExist = _service.IsFolderExist(directoriTo);

                if (!isFolderExist)
                {
                    _messegeService.ShowExclamation("Folder not found");
                    return;
                }

                await _service.DownloadAsync(queryString, directoriTo);
            }
            catch (Exception ex)
            {
                _messegeService.ShowError(ex.Message);
            }

            _messegeService.ShowMessage("loading is complete");
        }
    }
}
