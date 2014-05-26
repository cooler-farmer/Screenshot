using System;
using System.Drawing;
using System.Windows.Forms;

namespace Screenshot.Forms
{
    public sealed partial class SnippetDialog : Form
    {
        private readonly Pen _borderPen = new Pen(Color.Black, 1);
        private int _selectHeight, _selectHeighDraw;
        private int _selectWidth, _selectWidthDraw;
        private int _selectX, _selectXDraw;
        private int _selectY, _selectYDraw;

        private bool _drawing;
        private Rectangle _selectedArea, _selectedAreaDraw;

        public SnippetDialog()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public Bitmap SnippedImage { get; set; }

        private void SnippetForm_Load(object sender, EventArgs e)
        {
            Location = new Point(SystemInformation.VirtualScreen.Left, 0);
            Size = new Size(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            
            TopMost = true;
            Cursor = Cursors.Cross;

            var screenshot = ScreenshotProvider.TakeScreenshotAllScreens();
            BackgroundImage = screenshot;
        }

        private void SnippetDialog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            
            _selectX = System.Windows.Forms.Cursor.Position.X;
            _selectY = System.Windows.Forms.Cursor.Position.Y;

            _selectXDraw = e.X;
            _selectYDraw = e.Y;
            _drawing = true;
        }

        private void SnippetDialog_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_drawing) return;

            _selectWidth = System.Windows.Forms.Cursor.Position.X - _selectX;
            _selectHeight = System.Windows.Forms.Cursor.Position.Y - _selectY;

            _selectWidthDraw = e.X - _selectXDraw;
            _selectHeighDraw = e.Y - _selectYDraw;

            _selectedArea = new Rectangle(_selectX , _selectY, _selectWidth, _selectHeight);
            _selectedAreaDraw = new Rectangle(_selectXDraw, _selectYDraw, _selectWidthDraw, _selectHeighDraw);
            Invalidate();
        }

        private void SnippetDialog_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(_borderPen, _selectedAreaDraw);
        }

        private void SnippetDialog_MouseUp(object sender, MouseEventArgs e)
        {
            _drawing = false;
            Hide();

            //ensures border is not captured
            _selectedArea.Inflate(-1, -1);

            SnippedImage = ScreenshotProvider.TakeScreenshot(_selectedArea);
            DialogResult = DialogResult.OK;
        }


    }
}