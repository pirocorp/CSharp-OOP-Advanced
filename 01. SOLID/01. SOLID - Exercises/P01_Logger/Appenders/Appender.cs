namespace P01_Logger.Appenders
{
    using Enums;
    using Interfaces;

    public abstract class Appender : IAppender
    {
        protected readonly ILayout Layout;

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.Info;
        }

        public void Append(string message, ReportLevel reportLevel, string dateTime)
        {
            if (this.ReportLevel <= reportLevel)
            {
                this.AppendConcrete(message, reportLevel, dateTime);
            }
        }

        public abstract void AppendConcrete(string message, ReportLevel reportLevel, string dateTime);


        public ReportLevel ReportLevel { get; set; }
    }
}