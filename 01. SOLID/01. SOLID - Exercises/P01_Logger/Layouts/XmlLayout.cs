namespace P01_Logger.Layouts
{
    using System;
    using Enums;
    using Interfaces;

    public class XmlLayout : ILayout
    {
        public string Format(string message, ReportLevel reportLevel, string dateTime)
        {
            return "<log>" + Environment.NewLine +
                   $"   <date>{dateTime}</date>" + Environment.NewLine +
                   $"   <level>{reportLevel}</level>" + Environment.NewLine +
                   $"   <message>{message}</message>" + Environment.NewLine +
                   "</log>";
        }
    }
}