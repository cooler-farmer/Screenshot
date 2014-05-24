using System;
using System.Linq;
using System.Windows.Forms;

namespace Screenshot.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public string LocalSavePath
        {
            get
            {
                return localText.Text;
            }
        }

        public bool LocalBoolean
        {
            get
            {
                return localCheckBox.Checked;
            }
        }

        private void localPathBtn_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                localText.Text = dialog.SelectedPath;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}