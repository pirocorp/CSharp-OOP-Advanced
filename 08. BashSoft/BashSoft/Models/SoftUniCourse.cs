namespace BashSoft.Models
{
    using System.Collections.Generic;
    using Contracts.Models;
    using Exceptions;

    public class SoftUniCourse : ICourse
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;

        private readonly Dictionary<string, IStudent> studentsByName;

        public SoftUniCourse(string name)
        {
            this.name = name;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, IStudent> StudentsByName => this.studentsByName;

        public void EnrollStudent(IStudent softUniStudent)
        {
            if (this.studentsByName.ContainsKey(softUniStudent.Username))
            {
                throw new DuplicateEntryInStructureException(softUniStudent.Username, this.name);
            }

            this.studentsByName.Add(softUniStudent.Username, softUniStudent);
        }

        public int CompareTo(ICourse other) => this.Name.CompareTo(other.Name);

        public override string ToString() => this.Name;
    }
}
