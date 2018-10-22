namespace P07_InfernoInfinity.Core
{
    using System.Collections.Generic;
    using Interfaces;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory commandFactory;
        private readonly IDictionary<string, IWeapon> weapons;

        public CommandInterpreter(ICommandFactory commandFactory)
        {
            this.commandFactory = commandFactory;
            this.weapons = new Dictionary<string, IWeapon>();
        }

        public void InterpretCommand(string commandName, string[] data)
        {
            var command = this.commandFactory.CreateCommand(commandName, data, this.weapons);
            command.Execute();
        }
    }
}