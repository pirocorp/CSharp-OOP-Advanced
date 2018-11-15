namespace Travel.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Commands;
    using Contracts;
	using Controllers.Contracts;
	using IO.Contracts;

	public class Engine : IEngine
	{
		private readonly IReader reader;
		private readonly IWriter writer;

		private readonly IAirportController airportController;
		private readonly IFlightController flightController;

		public Engine(IReader reader, IWriter writer, IAirportController airportController,
			IFlightController flightController)
		{
			this.reader = reader;
			this.writer = writer;
			this.airportController = airportController;
			this.flightController = flightController;
		}

		public void Run()
		{
			while (true)
			{
				var input = this.reader.ReadLine();

				if (input == "END")
				{
					break;
				}

				try
				{
					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (InvalidOperationException ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split(' ');

			var commandAsString = tokens.First();
			var args = tokens.Skip(1).ToArray();

		    var commandInstance = this.CreateCommand(commandAsString);

		    return commandInstance.Execute(args);
		}

	    private ICommand CreateCommand(string commandAsString)
	    {
	        var commandType = Assembly.GetCallingAssembly()
	            .GetTypes()
	            .FirstOrDefault(t => t.Name == $"{commandAsString}Command");

	        if (commandType == null)
	        {
	            throw new System.InvalidOperationException("Invalid command!");
	        }

	        var commandConstructor = commandType.GetConstructors().First();

	        var parametersSource = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
	        var parametersTarget = commandConstructor.GetParameters();

	        var parameters = new object[parametersTarget.Length];

	        for (var i = 0; i < parametersTarget.Length; i++)
	        {
	            var currentTarget = parametersTarget[i];
	            var currentSource = parametersSource.First(p => p.FieldType == currentTarget.ParameterType);
	            parameters[i] = currentSource.GetValue(this);
	        }

	        var commandInstance = (ICommand) commandConstructor.Invoke(parameters);
	        return commandInstance;
	    }
	}
}