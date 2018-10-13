namespace P01_Logger.Layouts
{
    using System;
    using Enums;
    using Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format(string message, ReportLevel reportLevel, string dateTime)
        {
            return $"{dateTime} - {reportLevel} - {message}";
        }
    }
}