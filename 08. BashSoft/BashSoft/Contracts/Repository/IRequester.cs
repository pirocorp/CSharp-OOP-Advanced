namespace BashSoft.Contracts.Repository
{
    public interface IRequester
    {
        void GetStudentsByCourse(string courseName);

        void GetStudentMarkInCourse(string courseName, string username);
    }
}
