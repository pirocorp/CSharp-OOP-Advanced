namespace BashSoft.Contracts.DataStructures.SortingStrategies
{
    using System.Collections.Generic;

    public interface ISort<T>
    {
        void Sort(T[] inputElements, int startIndex, int endIndex, IComparer<T> comparator);
    }
}
