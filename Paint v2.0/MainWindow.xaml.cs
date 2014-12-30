using FirstFloor.ModernUI.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System;

namespace Paint_v2._0
{
    public partial class Paint : ModernWindow
    {
        private Point curPoint = new Point();

        public Paint()
        {
            InitializeComponent();
        }

        private enum Item
        {
            Rectangle, Ellipse, Line, Fill, Pencil, Eraser
        }

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

        private void Undo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {

        }

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

        private void MouseDown_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            curPoint = e.GetPosition(Paint_surface);

            Position.Content = curPoint.X + ", " + curPoint.Y + "px";
        }

        private void MouseUp_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Mouse_Leave(object sender, MouseEventArgs e)
        {
            Position.Content = "";
        }
    }
}
