using System;
using System.Runtime.InteropServices;
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
        public static ImageBrush CreateImageBrushFromVisual(Canvas paintSurface)
        {
            var bmp = CreateBitmapFromVisual(paintSurface);
            var bmpSo = TranslateImage.CreateBitmapSourceFromBitmap(bmp);
            var imgBrush = new ImageBrush(bmpSo);
            return imgBrush;
        }

        public static Bitmap CreateBitmapFromVisual(Canvas paintSurface)
        {
            var width = paintSurface.Width;
            var height = paintSurface.Height;

            var bmpSo = CreateBitmapSourceFromVisual(width, height, paintSurface);
            return CreateBitmapFromBitmapSource(bmpSo);
        }

        public static Bitmap BitmapSourceToBitmap(BitmapSource bmpSo)
        {
            var width = bmpSo.PixelWidth;
            var height = bmpSo.PixelHeight;
            var stride = width * ((bmpSo.Format.BitsPerPixel + 7) / 8);
            var ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(height * stride);
                bmpSo.CopyPixels(new Int32Rect(0, 0, width, height), ptr, height * stride, stride);
                using (var btm = new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, ptr))
                {
                    return new Bitmap(btm);
                }
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.FreeHGlobal(ptr);
            }
        }

        public static Bitmap CreateBitmapFromBitmapSource(BitmapSource bmpSo)
        {
            var stream = new MemoryStream();
            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmpSo));
            encoder.Save(stream);

            return new Bitmap(stream);
        }

        public static BitmapSource CreateBitmapSourceFromBitmap(Bitmap bmp)
        {
            var bmpSo = Imaging.CreateBitmapSourceFromHBitmap(
            bmp.GetHbitmap(),
            IntPtr.Zero,
            Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());

            return bmpSo;
        }

        public static BitmapSource CreateBitmapSourceFromImageSource(ImageSource imgSo)
        {
            return imgSo as BitmapSource;
        }
      
        private static BitmapSource CreateBitmapSourceFromVisual(Double width, Double height, Visual paintSurface)
        {
            if (paintSurface == null)
                return null;

            var bmpSo = new RenderTargetBitmap(
                (Int32)width,
                (Int32)height,
                96, 96, PixelFormats.Pbgra32);

            bmpSo.Render(paintSurface);

            return bmpSo;
        }

    }
}
