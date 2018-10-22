namespace P03_BarraksWars.Core
{
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory commandFactory;
        private readonly IRepository repository;
        private readonly IUnitFactory unitFactory;

        public CommandInterpreter(ICommandFactory commandFactory, IRepository repository, IUnitFactory unitFactory)
        {
            this.commandFactory = commandFactory;
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var command = this.commandFactory.CreateCommand(commandName, data, this.repository, this.unitFactory);
            return command;
        }
    }
}