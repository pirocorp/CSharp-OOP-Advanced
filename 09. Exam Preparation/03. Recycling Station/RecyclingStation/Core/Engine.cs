namespace RecyclingStation.Core
{
    using System;
    using Interfaces.Core;
    using Interfaces.IO;
    using IO;

    public class Engine : IEngine
    {
        private const string END_INPUT_COMMAND = "TimeToRecycle";

        private readonly ICommandHandler commandHandler;
        private readonly IReader consoleReader;
        private readonly IWriter consoleWriter;

        public Engine()
            :this(new CommandHandler(), new ConsoleReader(), new ConsoleWriter())
        {
        }

        public Engine(ICommandHandler commandHandler, IReader consoleReader, IWriter consoleWriter)
        {
            this.commandHandler = commandHandler;
            this.consoleReader = consoleReader;
            this.consoleWriter = consoleWriter;
        }

        public void Run()
        {
            string inputLine;

            while ((inputLine = this.consoleReader.ReadLine()) != END_INPUT_COMMAND)
            {
                try
                {
                    this.ProcessCommand(inputLine);
                }
                catch (Exception e)
                {
                    this.consoleWriter.WriteLine(e.Message);
                }
            }
        }

        private void ProcessCommand(string inputLine)
        {
            var inputTokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var command = inputTokens[0];

            var invokeParams = new object[0];

            if (inputTokens.Length == 2)
            {
                invokeParams = new object[1];
                invokeParams[0] = inputTokens[1].Split(new[] {"|"}, StringSplitOptions.RemoveEmptyEntries);
            }

            var method = this.commandHandler.GetType().GetMethod(command);

            if (method == null)
            {
                throw new ArgumentException("The passed in command is invalid!");
            }

            var result = method.Invoke(this.commandHandler, invokeParams);
            this.consoleWriter.WriteLine(result);
        }
    }
}