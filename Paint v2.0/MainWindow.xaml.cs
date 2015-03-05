using FirstFloor.ModernUI.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System;

namespace Paint_v2._0
{
    public partial class Paint : ModernWindow
    {
        private Point curPoint;
        private Item currItem;
        private Draw drawShape;
        private Brush brushColor;

        public Paint()
        {
            InitializeComponent();

            curPoint = new Point();
            currItem = Item.Pencil;
            brushColor = drawingColorBox.Background;
        }

        private enum Item
        {
            Rectangle, Ellipse, Line, Pencil, Eraser, Fill, ColorPicker
        }

        //File Options

        private void New_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Paint",
                         MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes || result == MessageBoxResult.No)
            {
                if (result == MessageBoxResult.Yes)
                    IO.save(paintSurface);
                EditOptions.clearUndoAndRedoLists();
                EditOptions.clearCanvas(paintSurface);
                this.Title = "Paint";
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Paint",
                         MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes || result == MessageBoxResult.No)
            {
                if (result == MessageBoxResult.Yes)
                    IO.open(paintSurface);
                EditOptions.clearUndoAndRedoLists();
                EditOptions.clearCanvas(paintSurface);
                this.Title = "Paint";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Title = IO.save(paintSurface);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Paint",
                         MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                IO.save(paintSurface);

                this.Close();
            }
            else if (result == MessageBoxResult.No)
            {
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {

            }
            else
                MessageBox.Show("Unexpected error. Try agine");
        }

        //Edit Optoins

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            var shape = EditOptions.undo();
            if (shape != null)
                paintSurface.Children.Remove(shape);
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            var shape = EditOptions.redo();
            if (shape != null)
                paintSurface.Children.Add(shape);
        }

        //Image Transformations

        private void VerticalFlip_Click(object sender, RoutedEventArgs e)
        {
			paintSurface.Background = ImageTransformations.flipVertical(paintSurface);
            paintSurface.Children.Clear();
        }

        private void HorizontalFlip_Click(object sender, RoutedEventArgs e)
        {
			paintSurface.Background = ImageTransformations.flipHorizontal(paintSurface);
            paintSurface.Children.Clear();
        }

        private void RightRotate_Click(object sender, RoutedEventArgs e)
        {
            paintSurface.Background = ImageTransformations.RotateImage(paintSurface, 90);
            paintSurface.Children.Clear();

            var tmp = paintSurface.Width;
            paintSurface.Width = paintSurface.Height;
            paintSurface.Height = tmp;

            CanvasSize.Content = paintSurface.Width.ToString() + " x " + paintSurface.Height.ToString();
        }

        private void LeftRotate_Click(object sender, RoutedEventArgs e)
        {
            paintSurface.Background = ImageTransformations.RotateImage(paintSurface, 270);
            paintSurface.Children.Clear();

            var tmp = paintSurface.Width;
            paintSurface.Width = paintSurface.Height;
            paintSurface.Height = tmp;

            CanvasSize.Content = paintSurface.Width.ToString() + " x " + paintSurface.Height.ToString();
        }

        private void Rotate180_Click(object sender, RoutedEventArgs e)
        {
            paintSurface.Background = ImageTransformations.RotateImage(paintSurface, 180);
            paintSurface.Children.Clear();

            var tmp = paintSurface.Width;
            paintSurface.Width = paintSurface.Height;
            paintSurface.Height = tmp;
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
                paintSurface.Background = ImageTools.fill(paintSurface, curPoint, brushColor);

            else if (currItem == Item.ColorPicker)
                brushColor = drawingColorBox.Background = ImageTools.pickColor(paintSurface, curPoint);

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

                 EditOptions.saveShape(drawShape.returnShape());
             }
        }

        private void Mouse_Leave(object sender, MouseEventArgs e)
        {
            Position.Content = "";
        }
    }
}
