using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using System;

namespace Paint_v2._0
{
    public partial class Paint
    {
        private bool _isPressed;
        private bool _isRotated;
        private Items _currItems;
        private Point _curPoint;
        private Draw _drawShape;
        private Brush _brushColor;

        public Paint()
        {
            InitializeComponent();

            _curPoint = new Point();
            _currItems = Items.Pencil;
            _brushColor = drawingColorBox.Background;
            _isRotated = false;
        }

        //File Options

        private void New_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Paint",
                         MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes || result == MessageBoxResult.No)
            {
                if (result == MessageBoxResult.Yes)
                    IO.Save(PaintSurface);

                EditOptions.ClearUndoAndRedoLists();
                EditOptions.ClearCanvas(PaintSurface);

                Title = "Untitled - Paint";

                PaintSurface.Width = 450;
                PaintSurface.Height = 350;
                CanvasSize.Content = PaintSurface.Width + " x " + PaintSurface.Height;

                var transform = new TranslateTransform
                {
                    X = 0,
                    Y = 0
                };
                CanvasResizeButton.RenderTransform = transform;
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Paint",
                         MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes || result == MessageBoxResult.No)
            {
                if (result == MessageBoxResult.Yes)
                    IO.Save(PaintSurface);

                EditOptions.ClearUndoAndRedoLists();
                EditOptions.ClearCanvas(PaintSurface);

                Title = IO.Open(PaintSurface);

                var width = Convert.ToInt32(PaintSurface.Width);
                var height = Convert.ToInt32(PaintSurface.Height);
                CanvasSize.Content = width + " x " + height;

                var transform = new TranslateTransform
                {
                    X = PaintSurface.Width - 450,
                    Y = 0 
                };
                CanvasResizeButton.RenderTransform = transform;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Title = IO.Save(PaintSurface);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Paint",
                         MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes || result == MessageBoxResult.No)
            {
                if (result == MessageBoxResult.Yes)
                    IO.Save(PaintSurface);
                Application.Current.Shutdown();
            }
        }

        private void Close_Click(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save changes?", "Paint",
                         MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes )
            {
                IO.Save(PaintSurface);
            }
        }

        //Edit Optoins

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            var shape = EditOptions.Undo();
            if (shape != null)
                PaintSurface.Children.Remove(shape);

            if (_isRotated)
            {
                var tmp = PaintSurface.Width;
                PaintSurface.Width = PaintSurface.Height;
                PaintSurface.Height = tmp;
                _isRotated = false;
            }


        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            var shape = EditOptions.Redo();
            if (shape != null)
                PaintSurface.Children.Add(shape);

            if (_isRotated)
            {
                var tmp = PaintSurface.Width;
                PaintSurface.Width = PaintSurface.Height;
                PaintSurface.Height = tmp;
                _isRotated = false;
            }
        }

        //Image Transformations

        private void VerticalFlip_Click(object sender, RoutedEventArgs e)
        {
            EditOptions.SaveCanvasImage(ImageTransformations.FlipVertical(PaintSurface));
        }

        private void HorizontalFlip_Click(object sender, RoutedEventArgs e)
        {
            EditOptions.SaveCanvasImage(ImageTransformations.FlipVertical(PaintSurface));
        }

        private void RightRotate_Click(object sender, RoutedEventArgs e)
        {
            EditOptions.SaveCanvasImage(ImageTransformations.RotateImage(PaintSurface, 90));

            CanvasSize.Content = PaintSurface.Width + " x " + PaintSurface.Height;

            var transform = new TranslateTransform
            {
                X = PaintSurface.Width - 450,
                Y = 0
            };
            CanvasResizeButton.RenderTransform = transform;
            _isRotated = true;
        }

        private void LeftRotate_Click(object sender, RoutedEventArgs e)
        {
           EditOptions.SaveCanvasImage(ImageTransformations.RotateImage(PaintSurface, 270));

            CanvasSize.Content = PaintSurface.Width + " x " + PaintSurface.Height;

            var transform = new TranslateTransform
            {
                X = PaintSurface.Width - 450,
                Y = 0
            };
            CanvasResizeButton.RenderTransform = transform;
            _isRotated = true;
        }

        private void Rotate180_Click(object sender, RoutedEventArgs e)
        {
            EditOptions.SaveCanvasImage(ImageTransformations.RotateImage(PaintSurface, 180));
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

        private void ChangeColor_Click(object sender, MouseButtonEventArgs e)
        {
            _curPoint = e.GetPosition(ColorWheel);
            _brushColor = drawingColorBox.Background = ImageTools.PickColor(ColorWheel.Source, _curPoint);
        }

        //Actions On Canvas

        private void CanvasMouseDown_Click(object sender, MouseButtonEventArgs e)
        {
            _curPoint = e.GetPosition(PaintSurface);
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
                    PaintSurface.Background = ImageTools.Fill(PaintSurface, _curPoint, _brushColor);
                    break;
                case Items.ColorPicker:
                    _brushColor = drawingColorBox.Background = ImageTools.PickColor(PaintSurface, _curPoint);
                    break;
            }

            if (_drawShape != null)
                _drawShape.GetStartCords(_curPoint.X, _curPoint.Y);
        }

        private void CanvasMouse_Move(object sender, MouseEventArgs e)
        {
            _curPoint = e.GetPosition(PaintSurface);
            Position.Content = _curPoint.X + ", " + _curPoint.Y + "px";

            if (e.LeftButton == MouseButtonState.Pressed && _drawShape != null)
            {
                PaintSurface.Children.Remove(_drawShape.ReturnShape());
                _drawShape.GetEndCords(_curPoint.X, _curPoint.Y);
                PaintSurface.Children.Add(_drawShape.ReturnShape());
            }
        }

        private void CanvasMouseUp_Click(object sender, MouseButtonEventArgs e)
        {
             if (_drawShape != null)
             {
                 PaintSurface.Children.Remove(_drawShape.ReturnShape());
                 _drawShape.GetEndCords(_curPoint.X, _curPoint.Y);

                 var finalyShape = _drawShape.ReturnShape();
                 PaintSurface.Children.Add(finalyShape);

                 var bmp = TranslateImage.CreateBitmapFromVisual(PaintSurface);

                 var bodyImage = new Image
                 {
                     Source = TranslateImage.CreateBitmapSourceFromBitmap(bmp)
                 };

                 PaintSurface.Children.Remove(finalyShape);
                 PaintSurface.Children.Add(bodyImage);
                 Canvas.SetTop(bodyImage, 0);
                 Canvas.SetLeft(bodyImage, 0);

                 EditOptions.SaveCanvasImage(bodyImage);
             }
        }

        private void CanvasMouse_Leave(object sender, MouseEventArgs e)
        {
            Position.Content = "";
        }

        //button to change canvas size

        private void CanvasResizeButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isPressed = e.ChangedButton == MouseButton.Left;
        }

        private void CanvasResizeButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isPressed = false;

            PaintSurface.Width = Mouse.GetPosition(MyDockPanel).X - 5;
            PaintSurface.Height = Mouse.GetPosition(MyDockPanel).Y - 5;

            CanvasSize.Content = PaintSurface.Width + " x " + PaintSurface.Height;

            var transform = new TranslateTransform
            {
                X = Mouse.GetPosition(myGrid).X,
                Y = Mouse.GetPosition(MyDockPanel).Y - PaintSurface.Height - 5,
            };
            CanvasResizeButton.RenderTransform = transform;
        }

        private void CanvasResizeButtonMove(object sender, MouseEventArgs e)
        {
            if (!_isPressed) return;

            var transform = new TranslateTransform
            {
                X = Mouse.GetPosition(myGrid).X,
                Y = Mouse.GetPosition(MyDockPanel).Y - PaintSurface.Height,
            };
            CanvasResizeButton.RenderTransform = transform;
        }
    }
}
