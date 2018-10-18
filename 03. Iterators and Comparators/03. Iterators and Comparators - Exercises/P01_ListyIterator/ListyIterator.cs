namespace P01_ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> items;
        private int index;

        public ListyIterator(IEnumerable<T> collection)
        {
            this.items = new List<T>(collection);
            this.index = 0;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return this.index < this.items.Count - 1;
        }

        public T Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.items[this.index];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.items.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public string PrintAll()
        {
            return string.Join(" ", this.items);
        }
    }
}