namespace P06_Twitter.IO
{
    using System;
    using Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object input)
        {
            Console.WriteLine(input);
        }

        public void Write(object input)
        {
            Console.Write(input);
        }
    }
}