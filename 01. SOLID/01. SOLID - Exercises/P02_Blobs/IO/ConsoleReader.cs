namespace _02.Blobs.IO
{
    using System;
    using Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            var result = Console.ReadLine();

            return result;
        }
    }
}