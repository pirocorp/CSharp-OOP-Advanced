namespace P01_ListyIterator
{
    using System;
    using System.Linq;
    using Core;
    using IO;

    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var collection = reader.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();

            var engine = new EngineIterator<string>(reader, writer, collection);

            engine.Run();
        }
    }
}
