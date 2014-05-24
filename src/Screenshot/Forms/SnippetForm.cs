using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Screenshot.Forms
{
    // Snippets Class. More efficient way?? 
    public partial class SnippetForm : Form
    {
        public Pen SelectPen;
        private int selectX;
        private int selectY;
        private int selectWidth;
        private int selectHeight;
        private bool start = false;

        public SnippetForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        
        public Image SnippedImage { get; set; }

        private void SnippetForm_Load(object sender, EventArgs e)
        {
            Hide();
            var printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height);
            var graphics = Graphics.FromImage(printscreen);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            using (var s = new MemoryStream())
            {
                printscreen.Save(s, ImageFormat.Bmp);
                snippetBox.Size = new Size(Width, Height);
                snippetBox.Image = Image.FromStream(s);
            }
            Show();
            Cursor = Cursors.Cross;
        }

        private void snippetBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (snippetBox.Image == null)
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                snippetBox.Refresh();
                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;
                snippetBox.CreateGraphics().DrawRectangle(SelectPen,
                    selectX, selectY, selectWidth, selectHeight);
            }
        }

        private void snippetBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectX = e.X;
                selectY = e.Y;
                SelectPen = new Pen(Color.Black, 1) { DashStyle = DashStyle.Solid };

                if (e.Button == MouseButtons.Right)
                {
                    snippetBox.Refresh();
                }
            }
        }

        private void snippetBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            
            if (selectWidth > 0)
            {
                snippetBox.Refresh();
                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;
                snippetBox.CreateGraphics().DrawRectangle(SelectPen, selectX,
                    selectY, selectWidth, selectHeight);

                var rect = new Rectangle(selectX, selectY, selectWidth, selectHeight);
                var originalImage = new Bitmap(snippetBox.Image, snippetBox.Width, snippetBox.Height);
                var img = new Bitmap(selectWidth, selectHeight);
                var g = Graphics.FromImage(img);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(originalImage, 0, 0, rect, GraphicsUnit.Pixel);
                SnippedImage = img;

                DialogResult = DialogResult.OK;
              //  Close();
            }
        }
    }
}