namespace P01_Logger
{
    using System;
    using Appenders;
    using Controllers;
    using Enums;
    using Files;
    using Layouts;
    using Loggers;

    public class Program
    {
        public static void Main()
        {
            var layout = new SimpleLayout();
            var controller = new ConsoleController();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                controller.ParseAppender(Console.ReadLine());
            }

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                controller.ParseMessage(inputLine);
            }

            Console.WriteLine(controller.PrintStatistics());
        }
    }
}
