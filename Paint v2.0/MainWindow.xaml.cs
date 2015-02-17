using FirstFloor.ModernUI.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System;

namespace Paint_v2._0
{
    public partial class Paint : ModernWindow
    {
        private Point curPoint = new Point();
        private Item currItem = Item.Pencil;
        private Draw drawShape;
        private Brush brushColor;

        public Paint()
        {
            InitializeComponent();

            brushColor = showDrawingColor.Background;
        }

        private enum Item
        {
            Rectangle, Ellipse, Line, Pencil, Eraser, Fill, ColorPicker
        }

        //File Options

        private void New_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        //Edit Optoins

        private void Undo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {

        }

        //Image Options

        private void VerticalFlip_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HorizontalFlip_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RightRotate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LeftRotate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Rotate180_Click(object sender, RoutedEventArgs e)
        {

        }

        //Choose Item

        private void Pencil_Click(object sender, RoutedEventArgs e)
        {
            currItem = Item.Pencil;
        }

        private void Eraser_Click(object sender, RoutedEventArgs e)
        {
            currItem = Item.Eraser;
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            currItem = Item.Fill;
        }

        private void ColorPicker_Click(object sender, RoutedEventArgs e)
        {
            currItem = Item.ColorPicker;
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            currItem = Item.Rectangle;
        }

        private void Ellipse_Click(object sender, RoutedEventArgs e)
        {
            currItem = Item.Ellipse;
        }

        private void Line_Click(object sender, RoutedEventArgs e)
        {
            currItem = Item.Line;
        }

        //Actions On Canvas

        private void MouseDown_Click(object sender, MouseButtonEventArgs e)
        {
            curPoint = e.GetPosition(paintSurface);
            drawShape = null;

            if (currItem == Item.Line)
                drawShape = new DrawLine(brushColor, 2);

            else if (currItem == Item.Rectangle)
                drawShape = new DrawRectangle(brushColor, 2);

            else if (currItem == Item.Ellipse)
                drawShape = new DrawEllipse(brushColor, 2);

            else if (currItem == Item.Pencil)
                drawShape = new DrawPolyline(brushColor, 2);

            else if (currItem == Item.Eraser)
                drawShape = new DrawPolyline(Brushes.White, 5);

            else if (currItem == Item.Fill)
                drawShape = new DrawEllipse(brushColor, 2); //change to Fill

            else if (currItem == Item.ColorPicker)
                drawShape = new DrawRectangle(brushColor, 2); // change to colorPicker

            if (drawShape != null)
                drawShape.getStartCords(curPoint.X, curPoint.Y);
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            curPoint = e.GetPosition(paintSurface);
            Position.Content = curPoint.X + ", " + curPoint.Y + "px";

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (drawShape != null)
                {
                    paintSurface.Children.Remove(drawShape.returnShape());
                    drawShape.getEndCords(curPoint.X, curPoint.Y);
                    paintSurface.Children.Add(drawShape.returnShape());
                }
            }
        }

        private void MouseUp_Click(object sender, MouseButtonEventArgs e)
        {
             if (drawShape != null)
             {
                 paintSurface.Children.Remove(drawShape.returnShape());
                 drawShape.getEndCords(curPoint.X, curPoint.Y);
                 paintSurface.Children.Add(drawShape.returnShape());
             }
        }

        private void Mouse_Leave(object sender, MouseEventArgs e)
        {
            Position.Content = "";
        }
    }
}
