namespace LambdaCore.Collection
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces.Collection;
    using Interfaces.Models;

    public class LStack : ILStack, IEnumerable<IFragment>
    {
        private readonly LinkedList<IFragment> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<IFragment>();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public IFragment Push(IFragment item)
        {
            this.innerList.AddLast(item);
            return item;
        }

        public void Pop()
        {
            this.innerList.RemoveLast();
        }

        public IFragment Peek()
        {
            var peekedItem = this.innerList.Last();
            return peekedItem;
        }

        public bool IsEmpty()
        {
            return this.innerList.Count == 0;
        }

        public IEnumerator<IFragment> GetEnumerator()
        {
            while (!this.IsEmpty())
            {
                yield return this.Peek();
                this.Pop();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IReadOnlyCollection<IFragment> Items => this.innerList.ToArray();
    }
}