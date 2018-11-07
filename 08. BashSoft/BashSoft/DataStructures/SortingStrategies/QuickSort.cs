namespace BashSoft.DataStructures.SortingStrategies
{
    using System.Collections.Generic;
    using Contracts.DataStructures.SortingStrategies;

    public class QuickSort<T> : ISort<T>
    {
        private T[] elements;
        private IComparer<T> comparator;

        public void Sort(T[] inputElements, int startIndex, int endIndex, IComparer<T> inputComparator)
        {
            this.elements = inputElements;
            this.comparator = inputComparator;

            this.QuickSortImplementation(startIndex, endIndex - 1);
        }

        public void QuickSortImplementation(int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            var value = this.elements[endIndex];
            var counter = startIndex;

            for (var i = startIndex; i < endIndex; i++)
            {
                if (this.comparator.Compare(this.elements[i], value) <= 0)
                {
                    this.Swap(i, counter);
                    counter++;
                }
            }

            this.Swap(counter, endIndex);
            this.QuickSortImplementation(startIndex, counter - 1);
            this.QuickSortImplementation(counter + 1, endIndex);
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var swap = this.elements[firstIndex];
            this.elements[firstIndex] = this.elements[secondIndex];
            this.elements[secondIndex] = swap;
        }
    }
}