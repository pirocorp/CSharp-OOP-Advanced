namespace BashSoft.IO
{
    using System;
    using Contracts;
    using Static_data;

    public class InputReader : IReader
    {
        private const string END_COMMAND = "quit";
        private readonly IInterpreter interpreter;

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }
        public  void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.CurrentPath}" + "> ");
            var input = Console.ReadLine().Trim();

            while (input != END_COMMAND)
            {
                this.interpreter.InterpretCommand(input);
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}" + "> ");
                input = Console.ReadLine().Trim();
            }
        }
    }
}
