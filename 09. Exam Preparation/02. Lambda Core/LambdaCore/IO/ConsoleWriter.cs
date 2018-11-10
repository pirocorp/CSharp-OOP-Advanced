namespace LambdaCore.IO
{
    using System;
    using Interfaces.IO;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

        public void Write(object obj)
        {
            Console.Write(obj);
        }
    }
}