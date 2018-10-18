﻿namespace P03_Stack
{
    using Core;
    using IO;

    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
