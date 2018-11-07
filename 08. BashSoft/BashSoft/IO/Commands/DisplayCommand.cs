namespace BashSoft.IO.Commands
{
    using System;
    using System.Collections.Generic;
    using Contracts.IO;
    using Contracts.Judge;
    using Contracts.Models;
    using Contracts.Repository;
    using Exceptions;

    internal class DisplayCommand : Command
    {
        public DisplayCommand(string input, string[] data, IContentComparer judge, IDatabase repository, 
            IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager) { }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            var entityToDisplay = this.Data[1];
            var sortType = this.Data[2];

            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {
                var studentComparator = this.CreateComparator<IStudent>(sortType);
                var list = this.Repository.GetAllStudentsSorted(studentComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else if(entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
            {
                var courseComparator = this.CreateComparator<ICourse>(sortType);
                var list = this.Repository.GetAllCoursesSorted(courseComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<T> CreateComparator<T>(string sortType)
            where T : IComparable<T>
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<T>.Create((elementOne, elementTwo) => elementOne.CompareTo(elementTwo));
            }

            if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<T>.Create((elementOne, elementTwo) => elementTwo.CompareTo(elementOne));
            }

            throw new InvalidCommandException(this.Input);
        }
    }
}