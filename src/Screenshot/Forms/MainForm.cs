using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Shortcut;

namespace Screenshot.Forms
{
    public partial class MainForm : Form
    {
        // Binder for ye Hotkeys (Sexy library Byte!)
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
        private readonly HotkeyBinder _hotkeyBinder2 = new HotkeyBinder();
        
        public MainForm()
        {
            InitializeComponent();

            // CTRL + ALT + Z = Snippet
            var hotKeyGetSnippet = new HotkeyCombination(Modifiers.Control | Modifiers.Alt, Keys.Z);
            // PrintScreen = Print entire screen
            var hotKeyPrintScrn = new HotkeyCombination(Modifiers.None, Keys.PrintScreen);
            _hotkeyBinder.Bind(hotKeyGetSnippet).To(HotKeyCallBackSnippets);
            _hotkeyBinder2.Bind(hotKeyPrintScrn).To(HotKeyCallBackPrintScreen);
        }

        private string localSavePath = string.Empty;
        private bool localSaveBool;

        private void HotKeyCallBackPrintScreen()
        {
            var prntImage = ScreenshotProvider.TakeScreenshot();
            
            if (localSaveBool)
            {
                // Checks for true on Settings Bool
                // Saves image to a random and unique filename, at the given file path
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
            // Load Snippet Form
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
            // Minimizes and hides MainForm 
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
            // Loads Settings Form and gets the values selected
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