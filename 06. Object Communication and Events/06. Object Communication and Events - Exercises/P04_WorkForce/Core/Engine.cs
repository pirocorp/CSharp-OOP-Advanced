namespace P04_WorkForce.Core
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Factories;
    using Interfaces;
    using IO;

    public class Engine
    {
        private readonly IDictionary<string, IEmployee> employees;
        private readonly JobList jobs;

        private readonly ICommandFactory commandFactory;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine()
            :this(new CommandFactory(), new ConsoleReader(), new ConsoleWriter())
        {

        }

        public Engine(ICommandFactory commandFactory, IReader reader, IWriter writer)
        {
            this.employees = new Dictionary<string, IEmployee>();
            this.jobs = new JobList();

            this.commandFactory = commandFactory;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            try
            {
                string inputLine;

                while ((inputLine = this.reader.ReadLine()) != "End")
                {
                    var tokens = inputLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    var commandName = tokens[0];

                    var currentCommand = this.commandFactory.CreateCommand(commandName, this.jobs, this.employees);
                    currentCommand.Execute(tokens);
                }
            }
            catch (Exception e)
            {
                this.writer.WriteLine(e.Message);
            }
        }
    }
}