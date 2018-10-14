namespace P01_Logger.Loggers
{
    using System.Collections.Generic;
    using Enums;
    using Interfaces;

    public class Logger
    {
        private readonly List<IAppender> appendDestinations;

        public Logger(params IAppender[] appenders)
        {
            this.appendDestinations = new List<IAppender>(appenders);
        }

        public IEnumerable<IAppender> Appenders => this.appendDestinations;

        public void AddAppender(IAppender appender)
        {
            this.appendDestinations.Add(appender);
        }

        public void Info(string dateTime, string message)
        {
            this.Append(message, ReportLevel.Info, dateTime);
        }

        public void Warning(string dateTime, string message)
        {
            this.Append(message, ReportLevel.Warning, dateTime);
        }

        public void Error(string dateTime, string message)
        {
            this.Append(message, ReportLevel.Error, dateTime);
        }

        public void Critical(string dateTime, string message)
        {
            this.Append(message, ReportLevel.Critical, dateTime);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Append(message, ReportLevel.Fatal, dateTime);
        }

        private void Append(string message, ReportLevel reportLevel, string dateTime)
        {
            foreach (var appendDestination in this.appendDestinations)
            {
                appendDestination.Append(message, reportLevel, dateTime);
            }
        }
    }
}