namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers.Contracts;
	using Entities.Contracts;
	using IO.Contracts;
	using System;
	using System.Linq;

    public class Engine : IEngine
	{
	    private readonly IReader reader;
	    private readonly IWriter writer;
	    private readonly IStage stage;
		private readonly IFestivalController festivalController;
		private readonly ISetController setController;

	    public Engine(IReader reader, IWriter writer, IStage stage, IFestivalController festivalController, ISetController setController)
	    {
	        this.reader = reader;
	        this.writer = writer;
	        this.stage = stage;
	        this.festivalController = festivalController;
	        this.setController = setController;
	    }

		public void Run()
		{
		    var input = string.Empty;
			while ((input = this.reader.ReadLine()) != "END") 
			{
				try
				{
					string.Intern(input);

					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex)
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalController.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split(" ".ToCharArray().First());

			var commandString = tokens.First();
			var commandArgs = tokens.Skip(1).ToArray();

			if (commandString == "LetsRock")
			{
				var result = this.setController.PerformSets();
				return result;
			}

			var commandMethod = this.festivalController
			    .GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == commandString);

			string output;

			try
			{
				output = (string)commandMethod.Invoke(this.festivalController, new object[] { commandArgs });
			}
			catch (TargetInvocationException ex)
			{
				throw ex.InnerException;
			}

			return output;
		}
	}
}