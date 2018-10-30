namespace ObjectCommunicationAndEventsLab.Interfaces
{
    using Enums;

    public interface IHandler
    {
        void Handle(LogType type, string message);

        void SetSuccessor(IHandler handler);
    }
}