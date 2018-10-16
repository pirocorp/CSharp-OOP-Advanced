namespace P08_CustomListSorter
{
    using Core;
    using IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}