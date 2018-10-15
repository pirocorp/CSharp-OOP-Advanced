namespace P01_Logger.Appenders
{
    using Enums;
    using Interfaces;

    public abstract class Appender : IAppender
    {
        protected readonly ILayout Layout;
        private int messagesAppended = 0;

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
                this.messagesAppended++;
            }
        }

        public ReportLevel ReportLevel { get; set; }

        public abstract void AppendConcrete(string message, ReportLevel reportLevel, string dateTime);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.messagesAppended}";
        }
    }
}