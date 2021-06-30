namespace CommandPattern
{
    using System;
    using System.Linq;
    using System.Reflection;
    using CommandPattern.Core.Contracts;
    using P10_CommandPattern.Core.Contracts;

    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandName)
        {
            var commandType = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType == null)
            {
                throw new ArgumentException($"{commandType} is invalid command type.");
            }

            return (ICommand)Activator.CreateInstance(commandType);
        }
    }
}