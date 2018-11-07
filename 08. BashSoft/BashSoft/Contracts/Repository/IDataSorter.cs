namespace BashSoft.Contracts.Repository
{
    using System.Collections.Generic;

    public interface IDataSorter
    {
        void OrderAndTake(Dictionary<string, double> studentsWithMark, string comparison, int studentsToTake);
    }
}