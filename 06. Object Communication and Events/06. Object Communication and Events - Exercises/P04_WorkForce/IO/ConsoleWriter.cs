namespace P04_WorkForce.IO
{
    using System;
    using Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object content)
        {
            Console.WriteLine(content);
        }

        public void Write(object content)
        {
            Console.Write(content);
        }
    }
}