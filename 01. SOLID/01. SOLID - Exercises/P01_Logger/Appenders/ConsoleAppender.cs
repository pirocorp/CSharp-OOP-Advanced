namespace P01_Logger.Appenders
{
    using System;
    using Enums;
    using Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout inputLayout) 
            : base(inputLayout)
        {
            
        }

        public override void AppendConcrete(string message, ReportLevel reportLevel, string dateTime)
        {
            Console.WriteLine(this.Layout.Format(message, reportLevel, dateTime));
        }
    }
}