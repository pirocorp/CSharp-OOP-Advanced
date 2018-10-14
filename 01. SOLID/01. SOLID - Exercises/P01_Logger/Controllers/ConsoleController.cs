namespace P01_Logger.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Appenders;
    using Enums;
    using Factories;
    using Interfaces;
    using Loggers;

    public class ConsoleController
    {
        private readonly Logger logger;
        private readonly LayoutFactory layoutFactory;
        private readonly AppenderFactory appenderFactory;

        public ConsoleController()
        {
            this.logger = new Logger();
            this.layoutFactory = new LayoutFactory();
            this.appenderFactory = new AppenderFactory();
        }

        //public ConsoleController(ILayout layout)
        //{
        //    this.logger = new List<IAppender>();
        //    this.InitializeAppenders(layout);
        //}

        //private void InitializeAppenders(ILayout layout)
        //{
        //    var currentAssembly = Assembly.GetExecutingAssembly();

        //    var types = currentAssembly.GetTypes()
        //        .Where(type => type.IsSubclassOf(typeof(Appender)))
        //        .ToList();

        //    foreach (var type in types)
        //    {
        //        var currentInstance = System.Activator.CreateInstance(type, new object[]{ layout }) as IAppender;
        //        this.logger.Add(currentInstance);
        //    }
        //}

        public void ParseAppender(string inputLine)
        {
            //<appender type> <layout type> <REPORT LEVEL> - last parameter is optional
            var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var appenderTypeString = tokens[0];
            var layoutTypeString = tokens[1];

            var layout = this.layoutFactory.Create(layoutTypeString);
            var appender = this.appenderFactory.Create(appenderTypeString, layout);

            if (tokens.Length > 2)
            {
                var reportLevelString = FormatStringFirstLetterCapital(tokens[2]);

                var isParsed = Enum.TryParse<ReportLevel>(reportLevelString, out var reportLevel);

                if (isParsed)
                {
                    appender.ReportLevel = reportLevel;
                }
                else
                {
                    throw new ArgumentException("Not supported report level.", "REPORT LEVEL");
                }
            }

            this.logger.AddAppender(appender);
        }

        public void ParseMessage(string inputLine)
        {
            //<REPORT LEVEL>|<time>|<message>
            var tokens = inputLine.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            
            var reportLevelString = FormatStringFirstLetterCapital(tokens[0]);

            var isParsed = Enum.TryParse<ReportLevel>(reportLevelString, out var reportLevel);

            if (!isParsed)
            {
                throw new ArgumentException("Not supported report level.", "REPORT LEVEL");
            }

            var dateTime = tokens[1];
            var message = tokens[2];

            this.AppendMessage(dateTime, message, reportLevel);
        }

        private static string FormatStringFirstLetterCapital(string inputString)
        {
            var reportLevelString = inputString.ToLower();
            reportLevelString = $"{char.ToUpper(reportLevelString.First())}{new string(reportLevelString.Skip(1).ToArray())}";
            return reportLevelString;
        }

        public void AppendMessage(string dateTime, string message, ReportLevel reportLevel)
        {
            switch (reportLevel)
            {
                case ReportLevel.Info:
                    this.logger.Info(dateTime, message);
                    break;
                case ReportLevel.Warning:
                    this.logger.Warning(dateTime, message);
                    break;
                case ReportLevel.Error:
                    this.logger.Error(dateTime, message);
                    break;
                case ReportLevel.Critical:
                    this.logger.Critical(dateTime, message);
                    break;
                case ReportLevel.Fatal:
                    this.logger.Fatal(dateTime, message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(reportLevel), reportLevel, null);
            }
        }

        public string PrintStatistics()
        {
            var result = new StringBuilder();

            foreach (var appender in this.logger.Appenders)
            {
                result.AppendLine(appender.ToString());
            }

            return result.ToString();
        }
    }
}