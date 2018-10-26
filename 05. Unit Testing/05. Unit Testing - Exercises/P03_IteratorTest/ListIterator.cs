namespace P03_IteratorTest
{
    using System;
    using System.Collections.Generic;

    public class ListIterator
    {
        private readonly IList<string> collectionOfStrings;
        private int index;

        public ListIterator(IEnumerable<string> inputStrings)
        {
            if (inputStrings == null)
            {
                throw new ArgumentNullException();
            }

            this.collectionOfStrings = new List<string>(inputStrings);
            this.index = 0;
        }

        public bool Move()
        {
            var next = this.HasNext();

            if (next)
            {
                this.index++;
            }

            return next;
        }

        public bool HasNext()
        {
            if (this.index < this.collectionOfStrings.Count - 1)
            {
                return true;
            }

            return false;
        }

        public string Print()
        {
            if (this.collectionOfStrings.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.collectionOfStrings[this.index];
        }
    }
}