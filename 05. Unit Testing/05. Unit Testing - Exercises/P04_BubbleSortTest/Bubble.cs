namespace P04_BubbleSortTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bubble <T> where T : IComparable
    {
        private readonly T[] elements;

        public Bubble(IEnumerable<T> elements)
        {
            this.elements = elements.ToArray();
        }

        public IEnumerable<T> Sort()
        {
            bool swapped;
            var indexOfLastUnsortedElement = this.elements.Length - 1;

            do
            {
                swapped = false;

                for (var i = 0; i < indexOfLastUnsortedElement; i++)
                {
                    var comparator = this.elements[i].CompareTo(this.elements[i + 1]);

                    if (comparator > 0)
                    {
                        var temp = this.elements[i + 1];
                        this.elements[i + 1] = this.elements[i];
                        this.elements[i] = temp;
                        swapped = true;
                    }
                }

                indexOfLastUnsortedElement--;

            } while (swapped);

            return this.elements;
        }
    }
}