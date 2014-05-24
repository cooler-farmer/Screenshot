using System;
using System.Drawing;
using System.Windows.Forms;

namespace Screenshot.Forms
{
    public sealed partial class SnippetDialog : Form
    {
        private readonly Pen borderPen = new Pen(Color.Black, 1);
        private int selectHeight;
        private int selectWidth;
        private int selectX;
        private int selectY;
        private bool drawing;
        private Rectangle selectedArea;

        public SnippetDialog()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public Image SnippedImage { get; set; }

        private void SnippetForm_Load(object sender, EventArgs e)
        {
            Location = Point.Empty;
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            TopMost = true;
            Cursor = Cursors.Cross;

            var screenshot = ScreenshotProvider.TakeScreenshot();
            BackgroundImage = screenshot;
        }

        private void SnippetDialog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            
            selectX = e.X;
            selectY = e.Y;
            drawing = true;
        }

        private void SnippetDialog_MouseMove(object sender, MouseEventArgs e)
        {
            if (!drawing) return;

            selectWidth = e.X - selectX;
            selectHeight = e.Y - selectY;
            selectedArea = new Rectangle(selectX , selectY, selectWidth, selectHeight);
            Invalidate();
        }

        private void SnippetDialog_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(borderPen, selectedArea);
        }

        private void SnippetDialog_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;

            // ensures border is not captured
            selectedArea.Inflate(-1, -1);

            SnippedImage = ScreenshotProvider.TakeScreenshot(selectedArea);
            DialogResult = DialogResult.OK;
        }


    }
}