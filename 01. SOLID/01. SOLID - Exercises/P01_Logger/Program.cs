namespace P01_Logger
{
    using System;
    using Controllers;
    using Layouts;

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
