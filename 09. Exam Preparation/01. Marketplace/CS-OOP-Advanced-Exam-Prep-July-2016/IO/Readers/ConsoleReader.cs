namespace CS_OOP_Advanced_Exam_Prep_July_2016.IO.Readers
{
    using System;
    using Framework.Lifecycle.Component;

    [Component]
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}