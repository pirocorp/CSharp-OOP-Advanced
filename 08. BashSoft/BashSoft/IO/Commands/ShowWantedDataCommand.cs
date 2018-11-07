namespace BashSoft.IO.Commands
{
    using Contracts.IO;
    using Contracts.Judge;
    using Contracts.Repository;
    using Exceptions;
    using Judge;
    using Repository;

    public class ShowWantedDataCommand : Command
    {
        public ShowWantedDataCommand(string input, string[] data, IContentComparer judge, IDatabase repository, 
            IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager) {}

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                var course = this.Data[1];
                this.Repository.GetStudentsByCourse(course);
            }
            else if (this.Data.Length == 3)
            {
                var course = this.Data[1];
                var username = this.Data[2];
                this.Repository.GetStudentMarkInCourse(course, username);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}
