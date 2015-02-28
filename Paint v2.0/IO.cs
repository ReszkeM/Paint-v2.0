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
        public static string open(Canvas paintSurface)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "BMP|*.bmp";

            Nullable<bool> result = ofd.ShowDialog();
            if (result == true)
            {
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(ofd.FileName.ToString()));

                paintSurface.Width = brush.ImageSource.Width;
                paintSurface.Height = brush.ImageSource.Height;

                paintSurface.Background = brush;

                return ofd.SafeFileName.ToString() + " - Paint";
            }
            return "Untitled - Paint";
        }

        public static string save(Canvas paintSurface)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP|*.bmp";

            Nullable<bool> result = sfd.ShowDialog();

            if (result == true)
            {
                int Height = (int)paintSurface.Height;
                int Width = (int)paintSurface.Width;
                string file_name = sfd.FileName.ToString();

                RenderTargetBitmap bmp = new RenderTargetBitmap(Width, Height, 96, 96, PixelFormats.Pbgra32);
                bmp.Render(paintSurface);

                BitmapEncoder bmpEncoder = new BmpBitmapEncoder();
                bmpEncoder.Frames.Add(BitmapFrame.Create(bmp));

                using (Stream fs = File.Create(file_name))
                    bmpEncoder.Save(fs);

                MessageBox.Show("Save successfully.");

                return sfd.FileName.ToString() + " - Paint";
            }

            return "Untitled - Paint";
        }

        private static void openFileDialog()
        {

        }
    }
}
