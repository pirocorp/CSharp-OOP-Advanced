namespace P01_Logger.Interfaces
{
    using System;
    using Enums;

    public interface IAppender
    {
        void Append(string message, ReportLevel reportLevel, string dateTime);
    }
}