using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Shortcut;

namespace Screenshot.Forms
{
    public partial class MainForm : Form
    {
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
        
        public MainForm()
        {
            InitializeComponent();
            InitializeHotkeyBinder();
        }

        private void InitializeHotkeyBinder()
        {
            _hotkeyBinder.Bind(Modifiers.Control | Modifiers.Alt, Keys.Z).To(HotKeyCallBackSnippets);
            _hotkeyBinder.Bind(Modifiers.None, Keys.PrintScreen).To(HotKeyCallBackPrintScreen);
        }

        private string localSavePath = string.Empty;
        private bool localSaveBool;

        private void HotKeyCallBackPrintScreen()
        {
            var prntImage = ScreenshotProvider.TakeScreenshot();
            
            if (localSaveBool)
            {
                try
                {
                    prntImage.Save(Path.Combine(string.Format("{0}\\", localSavePath), Guid.NewGuid() + ".jpg"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void HotKeyCallBackSnippets() 
        {
            var snippet = new SnippetForm();
            snippet.ShowDialog();

            if (snippet.DialogResult == DialogResult.OK)
            {
                try
                {
                    snippet.SnippedImage.Save(Path.Combine(string.Format("{0}\\", localSavePath), Guid.NewGuid() + ".jpg"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Hide();
        }

        private void exitIconMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsIconMenu_Click(object sender, EventArgs e)
        {
            var settings = new SettingsForm();
            settings.ShowDialog();
            if (settings.DialogResult == DialogResult.OK)
            {
                localSaveBool = settings.LocalBoolean;
                localSavePath = settings.LocalSavePath;
            }
        }
    }
}