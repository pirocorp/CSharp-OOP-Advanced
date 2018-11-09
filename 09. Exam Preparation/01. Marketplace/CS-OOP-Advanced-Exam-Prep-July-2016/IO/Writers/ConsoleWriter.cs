namespace CS_OOP_Advanced_Exam_Prep_July_2016.IO.Writers
{
    using System;
    using Framework.Lifecycle.Component;

    [Component]
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}