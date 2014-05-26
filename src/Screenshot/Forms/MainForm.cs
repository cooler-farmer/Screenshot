using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Screenshot.Classes;
using Shortcut;

namespace Screenshot.Forms
{
    public partial class MainForm : Form
    {
        #region " Variables "

        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
        private bool _customFileName = true;
        private string _customFileNamePattern = "dd-MM-yyyy_HH-mm-ss";
        private string _localSavePath = String.Empty;
        private bool _shouldSaveScreenshot;
        private bool _uploadScreenShot = true;

        #endregion

        public MainForm()
        {
            InitializeComponent();
            InitializeHotkeyBinder();
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (!File.Exists(Path.Combine(Application.StartupPath, "settings.ini")))
            {
                File.Create(Path.Combine(Application.StartupPath, "settings.ini")).Close();

                var ini = new IniFile(Path.Combine(Application.StartupPath, "settings.ini"));
                //The class needs absolut paths
                ini.IniWriteValue("CustomFileName", "Enabled", _customFileName ? "true" : "false");
                ini.IniWriteValue("CustomFileName", "Pattern", _customFileNamePattern);
                ini.IniWriteValue("SaveFile", "Enabled", _shouldSaveScreenshot ? "true" : "false");
                ini.IniWriteValue("SaveFile", "Path", _localSavePath);
                ini = null;
            }
            else
            {
                var ini = new IniFile(Path.Combine(Application.StartupPath, "settings.ini"));
                _customFileName = ini.IniReadValue("CustomFileName", "Enabled") == "true" ? true : false;
                _customFileNamePattern = ini.IniReadValue("CustomFileName", "Pattern");
                _shouldSaveScreenshot = ini.IniReadValue("SaveFile", "Enabled") == "true" ? true : false;
                _localSavePath = ini.IniReadValue("SaveFile", "Path");
                ini = null;
            }
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
                MessageBox.Show(
                    "The Application was unable to bind the Shortcuts" + Environment.NewLine +
                    "This normally happens when another application is already using the Hotkey:" + Environment.NewLine +
                    "\"PRINTSCREEN\"", "Unable to bind the hotkey", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CaptureFullScreen()
        {
            Bitmap screenshot = ScreenshotProvider.TakeScreenshotOneScreen(Screen.PrimaryScreen);
            DoAfterCaptureStuff(screenshot);
        }

        private void CaptureRegion()
        {
            using (var snippetDialog = new SnippetDialog())
            {
                snippetDialog.ShowDialog();

                if (snippetDialog.DialogResult == DialogResult.OK)
                {
                    DoAfterCaptureStuff(snippetDialog.SnippedImage);
                }
            }
        }

        private void DoAfterCaptureStuff(Bitmap img)
        {
            if (!_shouldSaveScreenshot) return;

            string imgpath = SavePicture(img);
            if(_uploadScreenShot)
                UploadPicture(imgpath);
        }

        private bool UploadPicture(string imgpath)
        {
            try
            {
                string result = PrntscrUploader.Upload(imgpath);
                Match match = Regex.Match(result, "data\":\"(.*?)\"");
                string uri = match.Groups[1].Value;

                result =
                    new StreamReader(WebRequest.CreateHttp(uri.Replace(@"\", "")).GetResponse().GetResponseStream())
                        .ReadToEnd();
                match = Regex.Match(result, "<meta name=\"twitter:image:src\" content=\"(.*?)\"");
                uri = match.Groups[1].Value;

                Clipboard.SetText(uri);
                notifyIcon1.ShowBalloonTip(1000, "Upload Completed",
                    "Upload completed!\nLink got copied into your clipboard\n" + uri, ToolTipIcon.Info);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string SavePicture(Image img)
        {
            try
            {
                if (_customFileName)
                {
                    string path = Path.Combine(_localSavePath,
                        DateTime.Now.ToString(_customFileNamePattern) + ".png");
                    img.Save(path);
                    return path;
                }
                else
                {
                    string path = Path.Combine(_localSavePath, Guid.NewGuid() + ".png");
                    img.Save(path);
                    return path;
                }
            }
            catch (NotSupportedException ex)
                //-		$exception	{"Das angegebene Pfadformat wird nicht unterstützt."}	System.Exception {System.NotSupportedException}
            {
                MessageBox.Show(
                    "The custon filename pattern isn't supported\nRecheck your pattern or disable the custom filename in the settings",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return null;
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

            var ini = new IniFile(Path.Combine(Application.StartupPath, "settings.ini"));
            ini.IniWriteValue("CustomFileName", "Enabled", _customFileName ? "true" : "false");
            ini.IniWriteValue("CustomFileName", "Pattern", _customFileNamePattern);
            ini.IniWriteValue("SaveFile", "Enabled", _shouldSaveScreenshot ? "true" : "false");
            ini.IniWriteValue("SaveFile", "Path", _localSavePath);
            ini = null;
        }
    }
}