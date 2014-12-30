using System;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Paint_v2._0
{
    class DrawRectangle : Draw
    {
        DrawRectangle(Brush brushColor, int brushThick)
        {
            _shape = new Rectangle();
            _shape.Stroke = brushColor;
            _shape.StrokeThickness = brushThick;
        }

        public override void getEndCords(double X, double Y)
        {
            //remove old ellipse

            base.getEndCords(X, Y);
            checkCords();

            //draw new ellipse
        }
    }
}
