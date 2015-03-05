using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Drawing;
using System.IO;

namespace Paint_v2._0
{
    class TranslateImage
    {
        public static ImageBrush createImageBrushFromVisual(Canvas paintSurface)
        {
            Bitmap bmp = createBitmapFromVisual(paintSurface);
            BitmapSource bmpSo = TranslateImage.createBitmapSourceFromBitmap(bmp);
            ImageBrush imgBrush = new ImageBrush(bmpSo);
            return imgBrush;
        }

        public static Bitmap createBitmapFromVisual(Canvas paintSurface)
        {
            Double width = paintSurface.Width;
            Double height = paintSurface.Height;

            BitmapSource bmpSo = CreateBitmapSourceFromVisual(width, height, paintSurface);
            return CreateBitmapFromBitmapSource(bmpSo);
        }

        public static BitmapSource createBitmapSourceFromBitmap(Bitmap bmp)
        {
            BitmapSource bmpSo = Imaging.CreateBitmapSourceFromHBitmap(
            bmp.GetHbitmap(),
            IntPtr.Zero,
            Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());

            return bmpSo;
        }

        private static BitmapSource CreateBitmapSourceFromVisual(Double width, Double height, Visual paintSurface)
        {
            if (paintSurface == null)
            {
                return null;
            }
            RenderTargetBitmap bmpSo = new RenderTargetBitmap(
                (Int32)width,
                (Int32)height,
                96, 96, PixelFormats.Pbgra32);

            bmpSo.Render(paintSurface);

            return bmpSo;
        }

        private static Bitmap CreateBitmapFromBitmapSource(BitmapSource bmpSo)
        {
            MemoryStream stream = new MemoryStream();
            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmpSo));
            encoder.Save(stream);

            return new Bitmap(stream);
        }
    }
}
