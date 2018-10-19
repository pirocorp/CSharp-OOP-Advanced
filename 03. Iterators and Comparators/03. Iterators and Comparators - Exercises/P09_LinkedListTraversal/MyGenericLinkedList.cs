namespace P09_LinkedListTraversal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyGenericLinkedList<T> : IEnumerable<T> where T : IComparable
    {
        private MyGenericLinkedListNode<T> root;

        public MyGenericLinkedList()
        {
            
        }

        public MyGenericLinkedList(T root)
        {
            this.root = new MyGenericLinkedListNode<T>(root);
        }

        public int Count
        {
            get
            {
                var count = 0;

                if (this.root == null)
                {
                    return count;
                }

                count++;
                var currentRoot = this.root;

                while (currentRoot.NextElement != null)
                {
                    count++;
                    currentRoot = currentRoot.NextElement;
                }

                return count;
            }
        }

        public void Add(T element)
        {
            if (this.root == null)
            {
                this.root = new MyGenericLinkedListNode<T>(element);
                return;
            }

            var currentRoot = this.root;

            while (currentRoot.NextElement != null)
            {
                currentRoot = currentRoot.NextElement;
            }

            currentRoot.NextElement = new MyGenericLinkedListNode<T>(element);
        }

        public bool Remove(T element)
        {
            if (this.root == null)
            {
                return false;
            }

            var currentRoot = this.root;

            if (currentRoot.Element.CompareTo(element) == 0)
            {
                this.root = currentRoot.NextElement;
                return true;
            }

            while (currentRoot.NextElement != null)
            {
                var next = currentRoot.NextElement;

                if (next.Element.CompareTo(element) == 0)
                {
                    currentRoot.NextElement = next.NextElement;
                    return true;
                }

                currentRoot = currentRoot.NextElement;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.root != null)
            {
                yield return this.root.Element;

                var currentRoot = this.root;

                while (currentRoot.NextElement != null)
                {
                    yield return currentRoot.NextElement.Element;
                    currentRoot = currentRoot.NextElement;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}