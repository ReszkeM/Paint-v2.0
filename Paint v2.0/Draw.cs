using System;
using System.Windows.Shapes;

namespace Paint_v2._0
{
    public abstract class Draw
    {
        protected double x1, x2, y1, y2;
        protected double tmpX1, tmpX2, tmpY1, tmpY2;
        //protected Shape _shape;

        public void getStartCords(double X, double Y)
        {
            x1 = X;
            y1 = Y;
        }

        public void getEndCords(double X, double Y)
        {
            x2 = X;
            y2 = Y;

            setCordsToFigure();
        }

        protected abstract void setCordsToFigure();

        public abstract Shape returnShape();

        protected void checkCords()
        {
            if (x2 <= x1)
            {
                tmpX1 = x2;
                tmpX2 = x1;
            }
            else
            {
                tmpX1 = x1;
                tmpX2 = x2;
            }
            if (y2 <= y1)
            {
                tmpY1 = y2;
                tmpY2 = y1;
            }
            else
            {
                tmpY1 = y1;
                tmpY2 = y2;
            }
        }
    }
}
