using System;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Paint_v2._0
{
    class DrawLine : Draw
    {
        DrawLine(Brush brushColor, int brushThick)
        {
            _shape = new Line();
            _shape.Stroke = brushColor;
            _shape.StrokeThickness = brushThick;
        }

        public override void getEndCords(double X, double Y)
        {
            //remove old ellipse

            base.getEndCords(X, Y);

            //draw new ellipse
        }
    }
}
