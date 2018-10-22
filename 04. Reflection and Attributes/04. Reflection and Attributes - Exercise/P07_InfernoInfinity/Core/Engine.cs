namespace P07_InfernoInfinity.Core
{
    using System;
    using Interfaces;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            try
            {
                string inputLine;

                while ((inputLine = this.reader.ReadLine()) != "END")
                {
                    var tokens = inputLine.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    var command = tokens[0];
                    this.commandInterpreter.InterpretCommand(command, tokens);
                }

            }
            catch (Exception e)
            {
                this.writer.WriteLine(e.Message);
            }
        }
    }
}