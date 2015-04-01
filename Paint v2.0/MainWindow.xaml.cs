using System.Diagnostics;
using FirstFloor.ModernUI.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using System;

namespace Paint_v2._0
{
    public partial class Paint : ModernWindow
    {
        private Point _curPoint;
        private Items _currItems;
        private Draw _drawShape;
        private Brush _brushColor;

        public Paint()
        {
            InitializeComponent();

            _curPoint = new Point();
            _currItems = Items.Pencil;
            _brushColor = drawingColorBox.Background;
        }

        //File Options

        private void New_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Paint",
                         MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes || result == MessageBoxResult.No)
            {
                if (result == MessageBoxResult.Yes)
                    IO.Save(paintSurface);

                EditOptions.ClearUndoAndRedoLists();
                EditOptions.ClearCanvas(paintSurface);

                this.Title = "Paint";

                paintSurface.Width = 450;
                paintSurface.Height = 350;
                CanvasSize.Content = paintSurface.Width + " x " + paintSurface.Height;
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Paint",
                         MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes || result == MessageBoxResult.No)
            {
                if (result == MessageBoxResult.Yes)
                    IO.Save(paintSurface);

                EditOptions.ClearUndoAndRedoLists();
                EditOptions.ClearCanvas(paintSurface);
                IO.Open(paintSurface);

                Title = "Paint";

                var width = Convert.ToInt32(paintSurface.Width);
                var height = Convert.ToInt32(paintSurface.Height);
                CanvasSize.Content = width + " x " + height;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Title = IO.Save(paintSurface);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Paint",
                         MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes || result == MessageBoxResult.No)
            {
                if (result == MessageBoxResult.Yes)
                    IO.Save(paintSurface);
                Application.Current.Shutdown();
            }
        }

        private void Close_Click(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Paint",
                         MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes )
            {
                IO.Save(paintSurface);
            }
        }

        //Edit Optoins

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            var shape = EditOptions.Undo();
            if (shape != null)
                paintSurface.Children.Remove(shape);
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            var shape = EditOptions.Redo();
            if (shape != null)
                paintSurface.Children.Add(shape);
        }

        //Image Transformations

        private void VerticalFlip_Click(object sender, RoutedEventArgs e)
        {
			paintSurface.Background = ImageTransformations.FlipVertical(paintSurface);
            paintSurface.Children.Clear();
        }

        private void HorizontalFlip_Click(object sender, RoutedEventArgs e)
        {
			paintSurface.Background = ImageTransformations.FlipHorizontal(paintSurface);
            paintSurface.Children.Clear();
        }

        private void RightRotate_Click(object sender, RoutedEventArgs e)
        {
            paintSurface.Background = ImageTransformations.RotateImage(paintSurface, 90);
            paintSurface.Children.Clear();

            var tmp = paintSurface.Width;
            paintSurface.Width = paintSurface.Height;
            paintSurface.Height = tmp;

            CanvasSize.Content = paintSurface.Width + " x " + paintSurface.Height;
        }

        private void LeftRotate_Click(object sender, RoutedEventArgs e)
        {
            paintSurface.Background = ImageTransformations.RotateImage(paintSurface, 270);
            paintSurface.Children.Clear();

            var tmp = paintSurface.Width;
            paintSurface.Width = paintSurface.Height;
            paintSurface.Height = tmp;

            CanvasSize.Content = paintSurface.Width + " x " + paintSurface.Height;
        }

        private void Rotate180_Click(object sender, RoutedEventArgs e)
        {
            paintSurface.Background = ImageTransformations.RotateImage(paintSurface, 180);
            paintSurface.Children.Clear();
        }

        //Choose Items

        private void Pencil_Click(object sender, RoutedEventArgs e)
        {
            _currItems = Items.Pencil;
        }

        private void Eraser_Click(object sender, RoutedEventArgs e)
        {
            _currItems = Items.Eraser;
        }

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            _currItems = Items.Fill;
        }

        private void ColorPicker_Click(object sender, RoutedEventArgs e)
        {
            _currItems = Items.ColorPicker;
        }

        private void Rectangle_Click(object sender, RoutedEventArgs e)
        {
            _currItems = Items.Rectangle;
        }

        private void Ellipse_Click(object sender, RoutedEventArgs e)
        {
            _currItems = Items.Ellipse;
        }

        private void Line_Click(object sender, RoutedEventArgs e)
        {
            _currItems = Items.Line;
        }

        //Actions On Canvas

        private void MouseDown_Click(object sender, MouseButtonEventArgs e)
        {
            _curPoint = e.GetPosition(paintSurface);
            _drawShape = null;

            switch (_currItems)
            {
                case Items.Line:
                    _drawShape = new DrawLine(_brushColor, 2);
                    break;
                case Items.Rectangle:
                    _drawShape = new DrawRectangle(_brushColor, 2);
                    break;
                case Items.Ellipse:
                    _drawShape = new DrawEllipse(_brushColor, 2);
                    break;
                case Items.Pencil:
                    _drawShape = new DrawPolyline(_brushColor, 2);
                    break;
                case Items.Eraser:
                    _drawShape = new DrawPolyline(Brushes.White, 5);
                    break;
                case Items.Fill:
                    paintSurface.Background = ImageTools.Fill(paintSurface, _curPoint, _brushColor);
                    break;
                case Items.ColorPicker:
                    _brushColor = drawingColorBox.Background = ImageTools.PickColor(paintSurface, _curPoint);
                    break;
            }

            if (_drawShape != null)
                _drawShape.GetStartCords(_curPoint.X, _curPoint.Y);
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            _curPoint = e.GetPosition(paintSurface);
            Position.Content = _curPoint.X + ", " + _curPoint.Y + "px";

            if (e.LeftButton == MouseButtonState.Pressed && _drawShape != null)
            {
                paintSurface.Children.Remove(_drawShape.ReturnShape());
                _drawShape.GetEndCords(_curPoint.X, _curPoint.Y);
                paintSurface.Children.Add(_drawShape.ReturnShape());
            }
        }

        private void MouseUp_Click(object sender, MouseButtonEventArgs e)
        {
             if (_drawShape != null)
             {
                 paintSurface.Children.Remove(_drawShape.ReturnShape());
                 _drawShape.GetEndCords(_curPoint.X, _curPoint.Y);

                 var finalyShape = _drawShape.ReturnShape();
                 paintSurface.Children.Add(finalyShape);
                 EditOptions.SaveShape(finalyShape);
             }
        }

        private void Mouse_Leave(object sender, MouseEventArgs e)
        {
            Position.Content = "";
        }

        private void ChangeColor_Click(object sender, MouseButtonEventArgs e)
        {
            _curPoint = e.GetPosition(ColorWheel);
            _brushColor = drawingColorBox.Background = ImageTools.PickColor(ColorWheel.Source, _curPoint);
        }
    }
}
