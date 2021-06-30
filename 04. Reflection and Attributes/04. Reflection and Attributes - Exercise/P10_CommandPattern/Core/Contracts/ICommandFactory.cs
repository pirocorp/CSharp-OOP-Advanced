namespace P10_CommandPattern.Core.Contracts
{
    using CommandPattern.Core.Contracts;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandType);
    }
}
