using System;
using System.Drawing;
using System.Windows.Forms;
using Screenshot.Windows;

namespace Screenshot
{
    internal static class ScreenshotProvider
    {
        public static Bitmap TakeScreenshot()
        {
            return TakeScreenshot(Screen.PrimaryScreen.Bounds);
        }

        public static Bitmap TakeScreenshot(Rectangle area)
        {
            // byteblast: use the windows api here because the managed equivalent has
            // bugs.

            IntPtr handleDesktopWindow = NativeMethods.GetDesktopWindow();
            IntPtr handleSource = NativeMethods.GetWindowDC(handleDesktopWindow);
            IntPtr handleDestination = NativeMethods.CreateCompatibleDC(handleSource);
            IntPtr handleBitmap = NativeMethods.CreateCompatibleBitmap(handleSource, area.Width, area.Height);
            IntPtr handleOldBitmap = NativeMethods.SelectObject(handleDestination, handleBitmap);

            NativeMethods.BitBlt(handleDestination, 0, 0, area.Width, area.Height, handleSource, area.X, area.Y,
                                 TernaryRasterOperations.SRCCOPY | TernaryRasterOperations.CAPTUREBLT);

            Bitmap desktopCapture = Image.FromHbitmap(handleBitmap);
            NativeMethods.SelectObject(handleDestination, handleOldBitmap);
            NativeMethods.DeleteObject(handleBitmap);
            NativeMethods.DeleteDC(handleDestination);
            NativeMethods.ReleaseDC(handleDesktopWindow, handleSource);

            return desktopCapture;
        }
    }
}