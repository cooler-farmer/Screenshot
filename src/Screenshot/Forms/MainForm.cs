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
            try //In case another application already uses the hotkey (In my case ShareX)
            {
                _hotkeyBinder.Bind(Modifiers.Control | Modifiers.Alt, Keys.Z).To(CaptureRegion);
                _hotkeyBinder.Bind(Modifiers.None, Keys.PrintScreen).To(CaptureFullScreen);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private string _localSavePath = String.Empty; //ToDo: use INI files to save and load the settings
        private bool _shouldSaveScreenshot = false;
        private bool _customFileName = true;
        private string _customFileNamePattern = "dd-MM-yyyy_HH-mm-ss";

        private void CaptureFullScreen()
        {
            var screenshot = ScreenshotProvider.TakeScreenshot();
            
            if (_shouldSaveScreenshot)
            {
                SavePicture(screenshot);
            }
        }

        private void CaptureRegion() //Bug: This works only on monitor 1 for me!
        {
            using (var snippetDialog = new SnippetDialog())
            {
                snippetDialog.ShowDialog();

                if (snippetDialog.DialogResult == DialogResult.OK)
                {
                    SavePicture(snippetDialog.SnippedImage);
                }
            }
        }

        private void SavePicture(Image img)
        {
            if (_shouldSaveScreenshot)
            {
                try
                {
                    if (_customFileName)
                        img.Save(Path.Combine(_localSavePath, DateTime.Now.ToString(_customFileNamePattern) + ".jpg")); 
                    else
                        img.Save(Path.Combine(_localSavePath, Guid.NewGuid() + ".jpg"));
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
            var settings = new SettingsForm
            {
                LocalBoolean = _shouldSaveScreenshot,
                LocalSavePath = _localSavePath,
                CustomFileNameBoolean = _customFileName,
                CustomFileNamePattern = _customFileNamePattern
            };

            settings.ShowDialog();
            if (settings.DialogResult != DialogResult.OK) return;

            _shouldSaveScreenshot = settings.LocalBoolean;
            _localSavePath = settings.LocalSavePath;
            _customFileName = settings.CustomFileNameBoolean;
            _customFileNamePattern = settings.CustomFileNamePattern;

        }
    }
}