namespace BashSoft.IO.Commands
{
    using Contracts;
    using Exceptions;
    using Judge;
    using Repository;

    public class ChangePathAbsoluteCommand : Command
    {
        public ChangePathAbsoluteCommand(string input, string[] data, Tester judge, StudentsRepository repository,
            IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager) { }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var absPath = this.Data[1];
            this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absPath);
        }
    }
}
