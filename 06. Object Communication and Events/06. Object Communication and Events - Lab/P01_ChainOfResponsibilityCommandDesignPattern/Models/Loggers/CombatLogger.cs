namespace ObjectCommunicationAndEventsLab.Models.Loggers
{
    using Enums;
    using System;
    
    public class CombatLogger : Logger
    {
        public override void Handle(LogType type, string message)
        {
            switch (type)
            {
                case LogType.Attack:
                case LogType.Magic:
                case LogType.Target:
                case LogType.Error:
                case LogType.Event:
                    Console.WriteLine(type.ToString() + ": " + message);
                    break;
            }

            this.PassToSuccessor(type, message);
        }
    }
}