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

        public static void SaveShape(Shape shape)
        {
            toUndo.Push(shape);
        }

        public static void ClearUndoAndRedoLists()
        {
            toUndo.Clear();
            toRedo.Clear();
        }

        public static void ClearCanvas(Canvas paintSurface)
        {
            paintSurface.Background = Brushes.White;
            paintSurface.Children.Clear();
        }

        public static Shape Undo()
        {
            if (toUndo.Count <= 0) return null;

            var tmp = toUndo.Pop();
            toRedo.Push(tmp);
            return tmp;
        }

        public static Shape Redo()
        {
            if (toRedo.Count <= 0) return null;

            var tmp = toRedo.Pop();
            toUndo.Push(tmp);
            return tmp;
        }
    }
}
