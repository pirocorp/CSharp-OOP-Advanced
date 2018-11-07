namespace BashSoft.DataStructures.SortingStrategies
{
    using System.Collections.Generic;
    using Contracts.DataStructures.SortingStrategies;

    public class SelectionSort<T> : ISort<T>
    {
        public void Sort(T[] inputElements, int startIndex, int endIndex, IComparer<T> comparator)
        {
            for (var firstUnsortedElementIndex = startIndex; firstUnsortedElementIndex < endIndex; firstUnsortedElementIndex++)
            {
                var minIndex = firstUnsortedElementIndex;

                for (var unsortedElementIndex = firstUnsortedElementIndex + 1; unsortedElementIndex < endIndex; unsortedElementIndex++)
                {
                    if (comparator.Compare(inputElements[unsortedElementIndex], inputElements[minIndex]) < 0)
                    {
                        minIndex = unsortedElementIndex;
                    }
                }

                var elementToSwap = inputElements[firstUnsortedElementIndex];
                inputElements[firstUnsortedElementIndex] = inputElements[minIndex];
                inputElements[minIndex] = elementToSwap;
            }
        }
    }
}