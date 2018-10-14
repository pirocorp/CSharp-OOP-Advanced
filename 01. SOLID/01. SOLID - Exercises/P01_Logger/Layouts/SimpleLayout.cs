namespace P01_Logger.Layouts
{
    using Enums;
    using Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format(string message, ReportLevel reportLevel, string dateTime)
        {
            return $"{dateTime} - {reportLevel.ToString().ToUpper()} - {message}";
        }
    }
}