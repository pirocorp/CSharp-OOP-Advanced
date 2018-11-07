namespace BashSoft.IO
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Contracts.IO;
    using Contracts.Judge;
    using Contracts.Repository;

    public class CommandInterpreter : IInterpreter
    {
        private readonly IContentComparer judge;
        private readonly IDatabase repository;
        private readonly IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            var data = input.Split();
            var commandName = data[0];

            try
            {
                var command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private IExecutable ParseCommand(string input, string commandString, string[] data)
        {
            var parametersForConstruction = new object[]
            {
                input,
                data,
            };

            var typeOfCommand = Assembly.GetExecutingAssembly()
                .GetTypes()
                .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                                   .Where(atr => atr.Equals(commandString))
                                   .ToArray().Length > 0);

            var typeOfInterpreter = typeof(CommandInterpreter);

            var fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldsOfInterpreter = typeOfInterpreter.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            var commandExecutable = (IExecutable)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            foreach (var field in fieldsOfCommand)
            {
                var attribute = field.GetCustomAttributes(typeof(InjectAttribute));

                if (attribute != null)
                {
                    if (fieldsOfInterpreter.Any(f => f.FieldType == field.FieldType))
                    {
                        field.SetValue(commandExecutable, 
                            fieldsOfInterpreter.First(x => x.FieldType == field.FieldType).GetValue(this));
                    }
                }
            }

            return commandExecutable;
        }
    }
}