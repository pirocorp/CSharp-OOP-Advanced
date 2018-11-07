namespace BashSoft.IO
{
    using System;
    using Commands;
    using Contracts.IO;
    using Exceptions;
    using Judge;
    using Repository;

    public class CommandInterpreter : IInterpreter
    {
        private readonly Tester judge;
        private readonly StudentsRepository repository;
        private readonly IDirectoryManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IDirectoryManager inputOutputManager)
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
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdRel":
                    return new ChangePathRelativelyCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "cdAbs":
                    return new ChangePathAbsoluteCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "readDb":
                    return new ReadDatabaseFromFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "filter":
                    return new FilterAndTakeCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "order":
                    return new OrderAndTakeCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "dropdb":
                    return new DropDbCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                case "show":
                    return new ShowWantedDataCommand(input, data, this.judge, this.repository, this.inputOutputManager);
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
