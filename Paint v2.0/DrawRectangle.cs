using System;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace Paint_v2._0
{
    class DrawRectangle : Draw
    {
        private Rectangle myRectangle;

        public DrawRectangle(Brush brushColor, int brushThick)
        {
            myRectangle = new Rectangle();
            myRectangle.Stroke = brushColor;
            myRectangle.StrokeThickness = brushThick;
        }

        protected override void setCordsToFigure()
        {
            checkCords();

            myRectangle.Width = tmpX2 - tmpX1;
            myRectangle.Height = tmpY2 - tmpY1;

            Canvas.SetLeft(myRectangle, tmpX1);
            Canvas.SetTop(myRectangle, tmpY1);
        }

        public override Shape returnShape()
        {
            return myRectangle;
        }
    }
}
