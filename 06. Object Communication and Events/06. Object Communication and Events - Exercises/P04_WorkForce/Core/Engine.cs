namespace P04_WorkForce.Core
{
    using System;
    using System.Collections.Generic;
    using Factories;
    using Interfaces;
    using IO;

    public class Engine
    {
        private readonly IDictionary<string, IEmployee> employees;
        private readonly IList<IJob> jobs;

        private readonly ICommandFactory commandFactory;
        private readonly IReader reader;

        public Engine()
            :this(new CommandFactory(), new ConsoleReader())
        {

        }

        public Engine(ICommandFactory commandFactory, IReader reader)
        {
            this.employees = new Dictionary<string, IEmployee>();
            this.jobs = new List<IJob>();

            this.commandFactory = commandFactory;
            this.reader = reader;
        }

        public void Run()
        {
            string inputLine;

            while ((inputLine = this.reader.ReadLine()) != "End")
            {
                var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var commandName = tokens[0];

                var currentCommand = this.commandFactory.CreateCommand(commandName, this.jobs, this.employees);
                currentCommand.Execute(tokens);
            }
        }
    }
}