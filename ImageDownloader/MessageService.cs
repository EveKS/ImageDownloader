using System.Windows.Forms;

namespace FileMoveTo
{
    public interface IMessageService
    {
        void ShowError(string error);
        void ShowExclamation(string exlamation);
        void ShowMessage(string message);
    }

    public class MessageService : IMessageService
    {
        void IMessageService.ShowExclamation(string exlamation)
        {
            MessageBox.Show(exlamation, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        void IMessageService.ShowError(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void IMessageService.ShowMessage(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
