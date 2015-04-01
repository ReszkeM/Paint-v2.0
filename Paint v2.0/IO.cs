using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace Paint_v2._0
{
    public static class IO
    {
        public static string Open(Canvas paintSurface)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "BMP|*.bmp";

            var result = ofd.ShowDialog();
            if (result != true) return "Untitled - Paint";

            var brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(ofd.FileName.ToString()));

            paintSurface.Width = brush.ImageSource.Width;
            paintSurface.Height = brush.ImageSource.Height;

            paintSurface.Background = brush;

            return ofd.SafeFileName + " - Paint";
        }

        public static string Save(Canvas paintSurface)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "BMP|*.bmp";

            var result = sfd.ShowDialog();

            if (result != true) return "Untitled - Paint";

            var height = (int)paintSurface.Height;
            var width = (int)paintSurface.Width;
            var fileName = sfd.FileName;

            var bmp = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(paintSurface);

            BitmapEncoder bmpEncoder = new BmpBitmapEncoder();
            bmpEncoder.Frames.Add(BitmapFrame.Create(bmp));

            using (Stream fs = File.Create(fileName))
                bmpEncoder.Save(fs);

            MessageBox.Show("Save successfully.");

            return sfd.FileName + " - Paint";
        }
    }
}
