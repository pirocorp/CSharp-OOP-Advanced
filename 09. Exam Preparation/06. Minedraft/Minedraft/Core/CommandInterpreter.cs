using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        var command = this.CreateCommand(args);

        var result = command.Execute();
        return result;
    }

    private ICommand CreateCommand(IList<string> args)
    {
        var commandName = args[0];

        var commandType = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == $"{commandName}Command");

        if (commandType == null)
        {
            throw new ArgumentException(string.Format(Constants.CommandNotFound, commandName));
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException(string.Format(Constants.CommandNotFound, commandName));
        }

        var ctor = commandType.GetConstructors().First();
        var parameters = this.GetParametersForConstructor(args, ctor);

        var command = (ICommand)ctor.Invoke(parameters);
        return command;
    }

    private object[] GetParametersForConstructor(IList<string> args, ConstructorInfo ctor)
    {
        var parameterInfos = ctor.GetParameters();
        var parameters = new object[parameterInfos.Length];

        for (var i = 0; i < parameterInfos.Length; i++)
        {
            var paramType = parameterInfos[i].ParameterType;

            if (paramType == typeof(IList<string>))
            {
                parameters[i] = args.Skip(1).ToList();
            }
            else
            {
                var thisPropertyInfo = this.GetType().GetProperties().FirstOrDefault(p => p.PropertyType == paramType);
                var thisPropertyValue = thisPropertyInfo.GetValue(this);
                parameters[i] = thisPropertyValue;
            }
        }

        return parameters;
    }
}