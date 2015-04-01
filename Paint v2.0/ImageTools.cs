using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Drawing;
using Brush = System.Windows.Media.Brush;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;

namespace Paint_v2._0
{
    public static class ImageTools
    {
        public static ImageBrush Fill(Canvas paintSurface, System.Windows.Point curPoint, Brush brushColor)
        {
            var bmp = TranslateImage.CreateBitmapFromVisual(paintSurface);

            var targetColor = bmp.GetPixel(Convert.ToInt32(curPoint.X), Convert.ToInt32(curPoint.Y));
            var repColor = ColorTranslator.FromHtml(brushColor.ToString());

            var p = new Point(Convert.ToInt32(curPoint.X), Convert.ToInt32(curPoint.Y));

            return FloodFill(bmp, p, targetColor, repColor);
        }

        public static SolidColorBrush PickColor(Canvas paintSurface, System.Windows.Point curPoint)
        {
            var bmp = TranslateImage.CreateBitmapFromVisual(paintSurface);
            bmp.GetPixel(Convert.ToInt32(curPoint.X), Convert.ToInt32(curPoint.Y));

            var color = bmp.GetPixel(Convert.ToInt32(curPoint.X), Convert.ToInt32(curPoint.Y));

            return new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
        }

        public static SolidColorBrush PickColor(ImageSource colorWheel, System.Windows.Point curPoint)
        {
            var bmpSo = TranslateImage.CreateBitmapSourceFromImageSource(colorWheel);
            var bmp = TranslateImage.CreateBitmapFromBitmapSource(bmpSo);

            bmp.GetPixel(Convert.ToInt32(curPoint.X), Convert.ToInt32(curPoint.Y));

            var color = bmp.GetPixel(Convert.ToInt32(curPoint.X), Convert.ToInt32(curPoint.Y));

            return new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
        }

        private static bool CompareColors(Color a, Color b)
        {
            return (a.ToArgb() & 0xffffff) == (b.ToArgb() & 0xffffff);
        }

        private static ImageBrush FloodFill(Bitmap bmp, Point p, Color targetColor, Color repColor)
        {
            var q = new Queue<Point>();
            q.Enqueue(p);

            while (q.Count > 0)
            {
                var n = q.Dequeue();
                if (!CompareColors(bmp.GetPixel(n.X, n.Y), targetColor))
                    continue;
                Point w = n,
                e = new Point(n.X + 1, n.Y);

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
            var bmpSo = TranslateImage.CreateBitmapSourceFromBitmap(bmp);
            return new ImageBrush(bmpSo);
        }
    }
}

