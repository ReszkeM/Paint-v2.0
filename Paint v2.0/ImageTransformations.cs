using System.Drawing;
using System.Windows.Media;
using System.Windows.Controls;

namespace Paint_v2._0
{
    public static class ImageTransformations
    {
        public static ImageBrush FlipVertical(Canvas paintSurface)
        {
            var bmp = TranslateImage.CreateBitmapFromVisual(paintSurface);

            bmp.RotateFlip(RotateFlipType.Rotate180FlipX);

            var bmpSo = TranslateImage.CreateBitmapSourceFromBitmap(bmp);

            return new ImageBrush(bmpSo);
        }

        public static ImageBrush FlipHorizontal(Canvas paintSurface)
        {
            var bmp = TranslateImage.CreateBitmapFromVisual(paintSurface);

            bmp.RotateFlip(RotateFlipType.Rotate180FlipY);

            var bmpSo = TranslateImage.CreateBitmapSourceFromBitmap(bmp);

            return new ImageBrush(bmpSo);
        }

        public static ImageBrush RotateImage(Canvas paintSurface, int angle)
        {
            var bmp = TranslateImage.CreateBitmapFromVisual(paintSurface);

            switch (angle)
            {
                case 90:
                    bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 180:
                    bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 270:
                    bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }

            var bmpSo = TranslateImage.CreateBitmapSourceFromBitmap(bmp);

            return new ImageBrush(bmpSo);
        }
    }
}
