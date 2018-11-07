namespace BashSoft.DataStructures.SortingStrategies
{
    using System.Collections.Generic;
    using Contracts.DataStructures.SortingStrategies;

    public class BubbleSort<T> : ISort<T>
    {
        public void Sort(T[] inputElements, int startIndex, int endIndex, IComparer<T> comparator)
        {
            var allElements = endIndex;
            var swapped = false;

            do
            {
                swapped = false;

                for (var i = startIndex; i < allElements - 1; i++)
                {
                    if (comparator.Compare(inputElements[i], inputElements[i + 1]) > 0)
                    {
                        var swap = inputElements[i];
                        inputElements[i] = inputElements[i + 1];
                        inputElements[i + 1] = swap;
                        swapped = true;
                    }
                }

                allElements--;
            } while (swapped);
        }
    }
}