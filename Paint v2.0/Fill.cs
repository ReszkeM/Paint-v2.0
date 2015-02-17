using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Drawing;
using Brush = System.Windows.Media.Brush;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using IoPath = System.IO.Path;


namespace Paint_v2._0
{
    public static class Fill
    {
        private static bool CompareColors(Color a, Color b)
        {
            return (a.ToArgb() & 0xffffff) == (b.ToArgb() & 0xffffff);
        }

        private static void FloodFill(Canvas paintSurface, Bitmap bmp, Point p, Color targetColor, Color repColor)
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

            paintSurface.Background = new ImageBrush(bitmapSource);
        }

        public static void GetBmp(Canvas paintSurface, Point p, Brush brush)
        {
            //IO.Save(paintSurface, "tmp.bmp");
            Bitmap bmp = new Bitmap("tmp.bmp");

            Color targetColor = bmp.GetPixel(p.X, p.Y);
            Color repColor = ColorTranslator.FromHtml(brush.ToString());

            FloodFill(paintSurface, bmp, p, targetColor, repColor);
        }
    }
}
