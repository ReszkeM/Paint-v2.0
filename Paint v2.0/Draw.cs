using System;
using System.Windows.Shapes;

namespace Paint_v2._0
{
    public abstract class Draw
    {
        protected double _x1, _x2, _y1, _y2;
        protected Shape _shape;
       
        public void getStartCords(double X, double Y)
        {
            _x1 = X;
            _y1 = Y;
        }

        public virtual void getEndCords(double X, double Y)
        {
            _x2 = X;
            _y2 = Y;
        }

        protected void checkCords()
        {
            if (_x2 <= _x1)
            {
                double tmp = _x2;
                _x2 = _x1;
                _x1 = tmp;
            }
            if (_y2 <= _y1)
            {
                double tmp = _y2;
                _y2 = _y1;
                _y1 = tmp;
            }

            _shape.Width = _x2 - _x1;
            _shape.Height = _y2 - _y1;

            //Canvas.SetLeft(_shape, _x1);
            //Canvas.SetTop(_shape, _y1);

            //Paint_surface.Children.Add(Ellipse);
            //Options.GetObjects(Ellipse);
        }
    }
}
