namespace ObjectCommunicationAndEventsLab.Interfaces
{
    public interface IExecutor
    {
        void ExecuteCommand(ICommand command);
    }
}