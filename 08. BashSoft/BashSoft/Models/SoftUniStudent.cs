namespace BashSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Models;
    using Exceptions;
    using Static_data;

    public class SoftUniStudent : IStudent
    {
        private string username;
        private readonly Dictionary<string, ICourse> enrolledCourses;
        private readonly Dictionary<string, double> marksByCourseName;

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.username = value;
            }
        }

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses => this.enrolledCourses;

        public IReadOnlyDictionary<string, double> MarksByCourseName => this.marksByCourseName;

        public SoftUniStudent(string userName)
        {
            this.Username = userName;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public void EnrollInCourse(ICourse softUniCourse)
        {
            if (this.enrolledCourses.ContainsKey(softUniCourse.Name))
            {
                throw new DuplicateEntryInStructureException(this.Username, softUniCourse.Name);
            }

            this.enrolledCourses.Add(softUniCourse.Name, softUniCourse);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
            {
                throw new ArgumentOutOfRangeException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private static double CalculateMark(int[] scores)
        {
            var percentageOfSolvedExam = scores.Sum() /
                (double)(SoftUniCourse.NumberOfTasksOnExam * SoftUniCourse.MaxScoreOnExamTask);
            var mark = percentageOfSolvedExam * 4 + 2;

            return mark;
        }
    }
}
