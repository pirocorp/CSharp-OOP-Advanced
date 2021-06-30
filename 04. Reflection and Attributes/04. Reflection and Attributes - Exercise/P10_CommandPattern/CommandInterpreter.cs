namespace CommandPattern
{
    using System;
    using System.Linq;
    using System.Reflection;
    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPostFix = "Command";

        public string Read(string args)
        {
            var tokens = args
                .Split()
                .ToArray();


            var commandName = tokens[0];
            var commandTypeName = commandName + CommandPostFix;

            var commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.Name == nameof(ICommand))) // <= Get all interfaces only with ICommand !
                .FirstOrDefault(t => t.Name == commandTypeName);

            if (commandType == null)
            {
                throw new InvalidOperationException("Command type is invalid!");
            }

            var command = Activator.CreateInstance(commandType) as ICommand;

            var readData = tokens.Skip(1).ToArray();
            var result = command.Execute(readData);

            return result;
        }
    }
}
