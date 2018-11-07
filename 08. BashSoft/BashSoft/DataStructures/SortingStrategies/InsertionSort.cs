namespace BashSoft.DataStructures.SortingStrategies
{
    using System.Collections.Generic;
    using Contracts.DataStructures.SortingStrategies;

    public class InsertionSort<T> : ISort<T>
    {
        public void Sort(T[] inputElements, int startIndex, int endIndex, IComparer<T> comparator)
        {
            for (var unsortedIndex = startIndex + 1; unsortedIndex < endIndex; unsortedIndex++)
            {
                for (var sortedIndex = unsortedIndex; sortedIndex > startIndex; sortedIndex--)
                {
                    if (comparator.Compare(inputElements[sortedIndex], inputElements[sortedIndex - 1]) < 0)
                    {
                        var swap = inputElements[sortedIndex - 1];
                        inputElements[sortedIndex - 1] = inputElements[sortedIndex];
                        inputElements[sortedIndex] = swap;
                    }
                }
            }
        }
    }
}