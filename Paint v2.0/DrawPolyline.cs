using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace Paint_v2._0
{
    class DrawPolyline : Draw
    {
        private Polyline myPolyline;
        private PointCollection myPointCollection;

        public DrawPolyline(Brush brushColor, int brushThick)
        {
            myPolyline = new Polyline();
            myPolyline.Stroke = brushColor;
            myPolyline.StrokeThickness = brushThick;
            myPolyline.FillRule = FillRule.EvenOdd;

            myPointCollection = new PointCollection();
        }

        protected override void setCordsToFigure()
        {
            Point Point = new Point(x2, y2);
            myPointCollection.Add(Point);
            myPolyline.Points = myPointCollection;
        }

        public override Shape returnShape()
        {
            return myPolyline;
        }
    }
}
