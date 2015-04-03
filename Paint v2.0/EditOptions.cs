using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Controls;


namespace Paint_v2._0
{
    public static class EditOptions
    {
        private static Stack<Image> toUndo = new Stack<Image>();
        private static Stack<Image> toRedo = new Stack<Image>();

        public static void SaveCanvasImage(Image canvasImage)
        {
            toUndo.Push(canvasImage);
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

        public static Image Undo()
        {
            if (toUndo.Count <= 0) return null;

            var tmp = toUndo.Pop();
            toRedo.Push(tmp);
            return tmp;
        }

        public static Image Redo()
        {
            if (toRedo.Count <= 0) return null;

            var tmp = toRedo.Pop();
            toUndo.Push(tmp);
            return tmp;
        }
    }
}
