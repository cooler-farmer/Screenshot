﻿using System;
using System.Diagnostics;
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
            _hotkeyBinder.Bind(Modifiers.Control | Modifiers.Alt, Keys.Z).To(CaptureRegion);
            _hotkeyBinder.Bind(Modifiers.None, Keys.PrintScreen).To(CaptureFullScreen);
        }

        private string localSavePath = string.Empty;
        private bool shouldSaveScreenshot;

        private void CaptureFullScreen()
        {
            var screenshot = ScreenshotProvider.TakeScreenshot();
            
            if (shouldSaveScreenshot)
            {
                try
                {
                    screenshot.Save(Path.Combine(string.Format("{0}\\", localSavePath), Guid.NewGuid() + ".jpg"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void CaptureRegion() 
        {
            using (var snippetDialog = new SnippetDialog())
            {
                snippetDialog.ShowDialog();

                if (snippetDialog.DialogResult == DialogResult.OK)
                {
                    var screenshot = snippetDialog.SnippedImage;
                    screenshot.Save("C:\\Users\\ByteBlast\\Desktop\\Screenshot.jpg");
                    Debugger.Break();

                    try
                    {
                        snippetDialog.SnippedImage.Save(Path.Combine(string.Format("{0}\\", localSavePath),
                            Guid.NewGuid() + ".jpg"));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
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
                shouldSaveScreenshot = settings.LocalBoolean;
                localSavePath = settings.LocalSavePath;
            }
        }
    }
}