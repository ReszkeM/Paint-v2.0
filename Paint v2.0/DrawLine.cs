using System;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Paint_v2._0
{
    class DrawLine : Draw
    {
        private Line myLine;

        public DrawLine(Brush brushColor, int brushThick)
        {
            myLine = new Line();
            myLine.Stroke = brushColor;
            myLine.StrokeThickness = brushThick;
        }

        protected override void setCordsToFigure()
        {
            myLine.X1 = x1;
            myLine.Y1 = y1;

            myLine.X2 = x2;
            myLine.Y2 = y2;
        }

        public override Shape returnShape()
        {
            return myLine;
        }
    }
}
