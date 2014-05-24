using System;
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
            set
            {
                localText.Text = value;
                
            }
        }

        public bool LocalBoolean
        {
            get
            {
                return localCheckBox.Checked;
            }
            set
            {
                localCheckBox.Checked = value;
                
            }
        }

        public bool CustomFileNameBoolean
        {
            get
            {
                return CustomFilenameCheckBox.Checked;
            }
            set
            {
                CustomFilenameCheckBox.Checked = value;
                
            }
        }

        public string CustomFileNamePattern
        {
            get
            {
                return CustomFilenameTextBox.Text;
            }
            set
            {
                CustomFilenameTextBox.Text = value;
                
            }
        }

        private void localPathBtn_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
                localText.Text = dialog.SelectedPath;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}