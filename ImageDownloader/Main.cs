using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDownloader
{
    public interface IMainForm
    {
        event EventHandler Download;

        string QueryString { get; }
        string SelectToPath { get; }
        string SetMessageToRichTextBox { set; }
        string SetMessageToLable { set; }
    }

    public partial class Main : Form, IMainForm
    {
        public event EventHandler Download;

        public Main()
        {
            InitializeComponent();
            btnTo.Click += BtnTo_Click;
            btnDovnload.Click += BtnDovnload_Click;
        }

        private void BtnDovnload_Click(object sender, EventArgs e)
        {
            Download?.Invoke(this, EventArgs.Empty);
            btnDovnload.Enabled = false;
        }

        public string SetMessageToRichTextBox
        {
            set
            {
                var settextAction = new Action(() => { richTextBoxResult.AppendText(value); });

                if (richTextBoxResult.InvokeRequired)
                    richTextBoxResult.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public string SetMessageToLable
        {
            set
            {
                var settextAction = new Action(() => { lbInfo.Text = value; });

                if (richTextBoxResult.InvokeRequired)
                    richTextBoxResult.Invoke(settextAction);
                else
                    settextAction();
            }
        }

        public string SelectToPath
        {
            get { return tbTo.Text; }
        }

        public string QueryString
        {
            get { return tbQuery.Text; }
        }

        private void BtnTo_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbTo.Text = dlg.SelectedPath;
            }
        }
    }
}
