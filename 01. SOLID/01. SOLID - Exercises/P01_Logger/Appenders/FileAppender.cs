namespace P01_Logger.Appenders
{
    using Enums;
    using Files;
    using Interfaces;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout inputLayout) 
            : base(inputLayout)
        {
            this.File = new LogFile();
        }

        public override void AppendConcrete(string message, ReportLevel reportLevel, string dateTime)
        {
            this.File.Write(this.Layout.Format(message, reportLevel, dateTime));
        }

        public LogFile File { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {this.File.Size}";
        }
    }
}