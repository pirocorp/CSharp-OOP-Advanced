namespace BashSoft.IO
{
    using System;
    using Commands;
    using Contracts.IO;
    using Contracts.Judge;
    using Contracts.Repository;
    using Exceptions;

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

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data);
                case "ls":
                    return new TraverseFoldersCommand(input, data);
                case "cmp":
                    return new CompareFilesCommand(input, data);
                case "cdRel":
                    return new ChangePathRelativelyCommand(input, data);
                case "cdAbs":
                    return new ChangePathAbsoluteCommand(input, data);
                case "readDb":
                    return new ReadDatabaseFromFileCommand(input, data);
                case "help":
                    return new GetHelpCommand(input, data);
                case "filter":
                    return new FilterAndTakeCommand(input, data);
                case "order":
                    return new OrderAndTakeCommand(input, data);
                case "dropDb":
                    return new DropDbCommand(input, data);
                case "show":
                    return new ShowWantedDataCommand(input, data);
                case "display":
                    return new DisplayCommand(input, data);
                //case "decOrder":
                //    break;
                //case "download":
                //    break;
                //case "downloadAsynch":
                //    break;
                default:
                    throw new InvalidCommandException(input);
            }
        }        
    }
}