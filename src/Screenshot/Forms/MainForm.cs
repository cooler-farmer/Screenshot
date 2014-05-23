using System;
using System.Windows.Forms;
using Shortcut;

namespace Screenshot.Forms
{
    public partial class MainForm : Form
    {
        // Binder for ye Hotkeys (Sexy library Byte!)
        private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
        
        public MainForm()
        {
            InitializeComponent();

            var hotKeyPrintScrn = new HotkeyCombination(Modifiers.None, Keys.PrintScreen);
            _hotkeyBinder.Bind(hotKeyPrintScrn).To(this.HotKeyCallBackPrintScreen);
        }

        private void HotKeyCallBackPrintScreen()
        {
            pictureBox.Image =
                ScreenshotProvider.TakeScreenshot();
        }
        
        private void buttonTakeScreenshot_Click(object sender, EventArgs e)
        {
            // nice and easy for anybody to use ^^ - couldnt be simpler ;) -Nick
            pictureBox.Image =
                ScreenshotProvider.TakeScreenshot();
        }
    }
}