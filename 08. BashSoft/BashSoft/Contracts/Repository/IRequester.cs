namespace BashSoft.Contracts.Repository
{
    using System.Collections.Generic;
    using DataStructures;
    using Models;

    public interface IRequester
    {
        void GetStudentsByCourse(string courseName);

        void GetStudentMarkInCourse(string courseName, string username);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> comparer);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> comparer);
    }
}
