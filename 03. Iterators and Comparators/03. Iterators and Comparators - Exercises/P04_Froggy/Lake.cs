namespace P04_Froggy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Lake : IEnumerable<int>
    {
        private List<int> odds;
        private Stack<int> evens;

        public Lake(IEnumerable<int> collection)
        {
            this.odds = new List<int>();
            this.evens = new Stack<int>();

            this.ProcessInput(collection);
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var odd in this.odds)
            {
                yield return odd;
            }

            foreach (var even in this.evens)
            {
                yield return even;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return $"{string.Join(" ", this.odds)} {string.Join(" ", this.evens)}";
        }

        private void ProcessInput(IEnumerable<int> collection)
        {
            var isEven = false;

            foreach (var item in collection)
            {
                if (isEven)
                {
                    this.evens.Push(item);
                    isEven = !isEven;
                }
                else
                {
                    this.odds.Add(item);
                    isEven = !isEven;
                }
            }
        }
    }
}