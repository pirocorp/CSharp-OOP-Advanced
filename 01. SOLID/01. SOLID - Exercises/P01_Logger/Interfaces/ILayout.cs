namespace P01_Logger.Interfaces
{
    using Enums;

    public interface ILayout
    {
        string Format(string message, ReportLevel reportLevel, string dateTime);
    }
}
