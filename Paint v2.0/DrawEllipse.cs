using System;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace Paint_v2._0
{
    class DrawEllipse : Draw
    {
        private Ellipse myEllipse;

        public DrawEllipse(Brush brushColor, int brushThick)
        {
            myEllipse = new Ellipse();
            myEllipse.Stroke = brushColor;
            myEllipse.StrokeThickness = brushThick;
        }

        protected override void setCordsToFigure()
        {
            checkCords();

            myEllipse.Width = tmpX2 - tmpX1;
            myEllipse.Height = tmpY2 - tmpY1;

            Canvas.SetLeft(myEllipse, tmpX1);
            Canvas.SetTop(myEllipse, tmpY1);
        }

        public override Shape returnShape()
        {
            return myEllipse;
        }
    }
}
