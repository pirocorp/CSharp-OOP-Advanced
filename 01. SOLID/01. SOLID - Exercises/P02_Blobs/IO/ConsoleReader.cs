namespace _02.Blobs.IO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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