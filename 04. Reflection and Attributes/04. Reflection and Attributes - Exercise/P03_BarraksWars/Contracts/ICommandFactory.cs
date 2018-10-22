namespace P03_BarraksWars.Contracts
{
    public interface ICommandFactory
    {
        IExecutable CreateCommand(string commandType, string[] data, IRepository repository, IUnitFactory unitFactory);
    }
}
