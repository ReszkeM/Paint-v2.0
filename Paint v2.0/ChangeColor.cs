using System;
using System.Windows.Media;

namespace Paint_v2._0
{
    public static class ChangeColor
    {
        public static void getPixel()
        {

        }

        public static Brush setNewColor()
        {
            SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

            return brush;
        }
    }
}
