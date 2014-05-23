using System;
using System.Windows.Forms;

namespace Screenshot.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonTakeScreenshot_Click(object sender, EventArgs e)
        {
            pictureBox.Image = 
                ScreenshotProvider.TakeScreenshot();
        }
    }
}
