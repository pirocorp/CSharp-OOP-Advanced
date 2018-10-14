namespace P01_Logger.Interfaces
{
    using Enums;

    public interface IAppender
    {
        void Append(string message, ReportLevel reportLevel, string dateTime);

        ReportLevel ReportLevel { get; set; }
    }
}