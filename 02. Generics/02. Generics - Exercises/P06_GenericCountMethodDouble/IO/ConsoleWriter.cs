namespace P06_GenericCountMethodDouble.IO
{
    using System;
    using Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string content)
        {
            Console.WriteLine(content);
        }
    }
}