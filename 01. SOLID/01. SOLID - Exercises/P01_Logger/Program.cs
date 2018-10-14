namespace P01_Logger
{
    using System;
    using Appenders;
    using Enums;
    using Files;
    using Layouts;
    using Loggers;

    public class Program
    {
        public static void Main()
        {
            var simpleLayout = new SimpleLayout();
            var xmlLayout = new XmlLayout();
            var file = new LogFile();
            var fileAppender = new FileAppender(xmlLayout);
            fileAppender.File = file;

            var logger = new Logger(fileAppender);

            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            Console.WriteLine(fileAppender.File.Size);
        }
    }
}
