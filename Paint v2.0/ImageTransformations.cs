using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Paint_v2._0
{
    public static class ImageTransformations
    {
        public static ImageBrush flipVertical(Canvas paintSurface)
        {
            Bitmap bmp = TranslateImage.createBitmapFromVisual(paintSurface);

            bmp.RotateFlip(RotateFlipType.Rotate180FlipX);

            BitmapSource bmpSo = TranslateImage.createBitmapSourceFromBitmap(bmp);

            return new ImageBrush(bmpSo);
        }

        public static ImageBrush flipHorizontal(Canvas paintSurface)
        {
            Bitmap bmp = TranslateImage.createBitmapFromVisual(paintSurface);

            bmp.RotateFlip(RotateFlipType.Rotate180FlipY);

            BitmapSource bmpSo = TranslateImage.createBitmapSourceFromBitmap(bmp);

            return new ImageBrush(bmpSo);
        }

        public static ImageBrush RotateImage(Canvas paintSurface, int angle)
        {
            Bitmap bmp = TranslateImage.createBitmapFromVisual(paintSurface);

            if (angle == 90)
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            else if (angle == 180)
                bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            else if (angle == 270)
                bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

            BitmapSource bmpSo = TranslateImage.createBitmapSourceFromBitmap(bmp);

            return new ImageBrush(bmpSo);
        }
    }
}
