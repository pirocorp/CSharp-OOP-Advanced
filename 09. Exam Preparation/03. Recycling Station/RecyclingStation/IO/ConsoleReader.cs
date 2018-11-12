namespace RecyclingStation.IO
{
    using System;
    using Interfaces.IO;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}