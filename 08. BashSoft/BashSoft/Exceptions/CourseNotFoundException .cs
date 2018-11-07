namespace BashSoft.Exceptions
{
    using System;

    public class CourseNotFoundException : Exception
    {
        private const string NOT_ENROLLED_IN_COURSE = "SoftUniStudent must be enrolled in a course before you set his mark.";
        public CourseNotFoundException() : base(NOT_ENROLLED_IN_COURSE) { }
        public CourseNotFoundException(string message) : base(message) { }
    }
}
