using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Drawing;
using System.IO;
using Brush = System.Windows.Media.Brush;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using IoPath = System.IO.Path;


namespace Paint_v2._0
{
    public static class ImageTools
    {
        public static ImageBrush fill(Canvas paintSurface, System.Windows.Point curPoint, Brush brushColor)
        {
            Bitmap bmp = createBitmapFromVisual(paintSurface);

            Color targetColor = bmp.GetPixel(Convert.ToInt32(curPoint.X), Convert.ToInt32(curPoint.Y));
            Color repColor = ColorTranslator.FromHtml(brushColor.ToString());

            Point p = new Point(Convert.ToInt32(curPoint.X), Convert.ToInt32(curPoint.Y));

            return FloodFill(bmp, p, targetColor, repColor);
        }

        public static SolidColorBrush pickColor(Canvas paintSurface, System.Windows.Point curPoint)
        {
            Bitmap bmp = createBitmapFromVisual(paintSurface);
            bmp.GetPixel(Convert.ToInt32(curPoint.X), Convert.ToInt32(curPoint.Y));

            Color color = bmp.GetPixel(Convert.ToInt32(curPoint.X), Convert.ToInt32(curPoint.Y));

            return new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
        }

        public static ImageBrush createImageBrushFromVisual(Canvas paintSurface)
        {
            Bitmap bmp = createBitmapFromVisual(paintSurface);

            ImageBrush imgBrush = new ImageBrush(createBitmapSourceFromBitmap(bmp));

            return imgBrush;
        }

        private static bool CompareColors(Color a, Color b)
        {
            return (a.ToArgb() & 0xffffff) == (b.ToArgb() & 0xffffff);
        }

        private static ImageBrush FloodFill(Bitmap bmp, Point p, Color targetColor, Color repColor)
        {
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(p);

            while (q.Count > 0)
            {
                Point n = q.Dequeue();
                if (!CompareColors(bmp.GetPixel(n.X, n.Y), targetColor))
                    continue;
                Point w = n,
                e = new System.Drawing.Point(n.X + 1, n.Y);

                while ((w.X > 0) && CompareColors(bmp.GetPixel(w.X, w.Y), targetColor))
                {
                    bmp.SetPixel(w.X, w.Y, repColor);
                    if ((w.Y > 0) && CompareColors(bmp.GetPixel(w.X, w.Y - 1), targetColor))
                        q.Enqueue(new Point(w.X, w.Y - 1));
                    if ((w.Y < bmp.Height - 1) && CompareColors(bmp.GetPixel(w.X, w.Y + 1), targetColor))
                        q.Enqueue(new Point(w.X, w.Y + 1));
                    w.X--;
                }
                while ((e.X < bmp.Width - 1) && CompareColors(bmp.GetPixel(e.X, e.Y), targetColor))
                {
                    bmp.SetPixel(e.X, e.Y, repColor);
                    if ((e.Y > 0) && CompareColors(bmp.GetPixel(e.X, e.Y - 1), targetColor))
                        q.Enqueue(new Point(e.X, e.Y - 1));
                    if ((e.Y < bmp.Height - 1) && CompareColors(bmp.GetPixel(e.X, e.Y + 1), targetColor))
                        q.Enqueue(new Point(e.X, e.Y + 1));
                    e.X++;
                }
            }

            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
            bmp.GetHbitmap(),
            IntPtr.Zero,
            Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());

            return new ImageBrush(bitmapSource);
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

        private static Bitmap createBitmapFromVisual(Canvas paintSurface)
        {
            Double width = paintSurface.Width;
            Double height = paintSurface.Height;

            BitmapSource bmpSo = CreateBitmapSourceFromVisual(width, height, paintSurface);
            return CreateBitmapFromBitmapSource(bmpSo);
        }

        private static BitmapSource createBitmapSourceFromBitmap(Bitmap bmp)
        {
            BitmapSource bmpSo = Imaging.CreateBitmapSourceFromHBitmap(
            bmp.GetHbitmap(),
            IntPtr.Zero,
            Int32Rect.Empty,
            BitmapSizeOptions.FromEmptyOptions());

            return bmpSo;
        }
    }
}
