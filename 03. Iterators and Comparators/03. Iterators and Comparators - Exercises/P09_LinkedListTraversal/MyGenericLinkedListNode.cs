namespace P09_LinkedListTraversal
{
    using System;

    public class MyGenericLinkedListNode<T> where T : IComparable
    {
        public MyGenericLinkedListNode(T element)
        {
            this.Element = element;
        }

        public T Element { get; set; }

        public MyGenericLinkedListNode<T> NextElement { get; set; }
    }
}