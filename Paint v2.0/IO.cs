﻿using System;
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

            var bodyImage = new Image
            {
                Source = new BitmapImage(new Uri(ofd.FileName)),
            };

            paintSurface.Width = bodyImage.Source.Width;
            paintSurface.Height = bodyImage.Source.Height;

            paintSurface.Children.Add(bodyImage);
            Canvas.SetTop(bodyImage, 0);
            Canvas.SetLeft(bodyImage, 0);

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
