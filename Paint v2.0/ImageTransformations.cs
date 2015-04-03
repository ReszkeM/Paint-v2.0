using System.Drawing;
using System.Windows.Controls;
using DrawingImage = System.Drawing.Image;
using ControlsImage = System.Windows.Controls.Image;

namespace Paint_v2._0
{
    public static class ImageTransformations
    {
        public static ControlsImage FlipVertical(Canvas paintSurface)
        {
            var bmp = TranslateImage.CreateBitmapFromVisual(paintSurface);

            bmp.RotateFlip(RotateFlipType.Rotate180FlipX);

            var bodyImage = new ControlsImage
            {
                Source = TranslateImage.CreateBitmapSourceFromBitmap(bmp)
            };

            paintSurface.Children.Clear();
            paintSurface.Children.Add(bodyImage);
            Canvas.SetTop(bodyImage, 0);
            Canvas.SetLeft(bodyImage, 0);

            return bodyImage;
        }

        public static ControlsImage FlipHorizontal(Canvas paintSurface)
        {
            var bmp = TranslateImage.CreateBitmapFromVisual(paintSurface);

            bmp.RotateFlip(RotateFlipType.Rotate180FlipY);

            var bodyImage = new ControlsImage
            {
                Source = TranslateImage.CreateBitmapSourceFromBitmap(bmp)
            };

            paintSurface.Children.Add(bodyImage);
            Canvas.SetTop(bodyImage, 0);
            Canvas.SetLeft(bodyImage, 0);

            return bodyImage;
        }

        public static ControlsImage RotateImage(Canvas paintSurface, int angle)
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

            var bodyImage = new ControlsImage
            {
                Source = TranslateImage.CreateBitmapSourceFromBitmap(bmp)
            };

            paintSurface.Children.Add(bodyImage);
            Canvas.SetTop(bodyImage, 0);
            Canvas.SetLeft(bodyImage, 0);

            var tmp = paintSurface.Width;
            paintSurface.Width = paintSurface.Height;
            paintSurface.Height = tmp;

            return bodyImage;
        }
    }
}
