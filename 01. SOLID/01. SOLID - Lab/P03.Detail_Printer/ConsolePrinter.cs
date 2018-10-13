namespace P03.Detail_Printer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsolePrinter : IPrint
    {
        public void Print(string content)
        {
            Console.WriteLine(content);
        }
    }
}