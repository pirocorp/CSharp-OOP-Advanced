namespace P02.Graphic_Editor
{
    public class Program
    {
        public static void Main()
        {
            var shapes = new IShape[]
            {
                new Circle(),
                new Rectangle(),
                new Square(),
            };

            var graphicEditor = new GraphicEditor();

            foreach (var shape in shapes)
            {
                graphicEditor.DrawShape(shape);
            }
        }
    }
}
