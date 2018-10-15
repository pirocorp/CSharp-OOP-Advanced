namespace _02.Blobs
{
    using Core;
    using IO;

    public class Program
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Controller(writer, reader);
            engine.Run();
        }
    }
}
