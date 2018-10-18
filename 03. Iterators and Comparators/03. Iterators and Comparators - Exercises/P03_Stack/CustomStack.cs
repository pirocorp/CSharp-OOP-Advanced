namespace P03_Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomStack<T> : IEnumerable<T>
    {
        private readonly List<T> elements;

        public CustomStack()
        {
            this.elements = new List<T>();
        }

        public void Push(params T[] inputElements)
        {
            this.elements.AddRange(inputElements);
        }

        public T Pop()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            var lastIndex = this.elements.Count - 1;
            var lastElement = this.elements[lastIndex];
            this.elements.RemoveAt(lastIndex);

            return lastElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = this.elements.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}