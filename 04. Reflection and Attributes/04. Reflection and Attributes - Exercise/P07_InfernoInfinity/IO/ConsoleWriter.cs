namespace P07_InfernoInfinity.IO
{
    using System;
    using Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object content)
        {
            Console.WriteLine(content);
        }
    }
}