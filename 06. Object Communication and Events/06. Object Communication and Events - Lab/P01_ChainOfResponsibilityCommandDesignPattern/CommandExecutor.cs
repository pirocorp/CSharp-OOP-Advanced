 namespace ObjectCommunicationAndEventsLab
{
    using Interfaces;

    public class CommandExecutor : IExecutor
    {
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
}