namespace P03_GenericSwapMethodString
{
    using P03_GenericSwapMethodString.Core;
    using P03_GenericSwapMethodString.IO;

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
