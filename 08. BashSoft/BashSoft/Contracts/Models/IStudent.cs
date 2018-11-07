namespace BashSoft.Contracts.Models
{
    using System;
    using System.Collections.Generic;

    public interface IStudent : IComparable<IStudent>
    {
        IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }

        IReadOnlyDictionary<string, double> MarksByCourseName { get; }

        string Username { get; }

        void EnrollInCourse(ICourse softUniCourse);

        void SetMarkOnCourse(string courseName, params int[] scores);
    }
}