using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;


namespace Paint_v2._0
{
    public static class EditOptions
    {
        private static Stack<Shape> toUndo = new Stack<Shape>();
        private static Stack<Shape> toRedo = new Stack<Shape>();

        public static void saveShape(Shape shape)
        {
            toUndo.Push(shape);
        }

        public static void clearUndoAndRedoLists()
        {
            toUndo.Clear();
            toRedo.Clear();
        }

        public static void clearCanvas(Canvas paintSurface)
        {
            paintSurface.Background = Brushes.White;
            paintSurface.Children.Clear();
        }

        public static Shape undo()
        {
            if (toUndo.Count > 0)
            {
                Shape tmp = toUndo.Pop();
                toRedo.Push(tmp);
                return tmp;
            }
            return null;
        }

        public static Shape redo()
        {
            if (toRedo.Count > 0)
            {
                Shape tmp = toRedo.Pop();
                toUndo.Push(tmp);
                return tmp;
            }
            return null;
        }
    }
}
