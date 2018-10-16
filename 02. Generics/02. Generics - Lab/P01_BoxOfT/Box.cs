namespace P01_BoxOfT
{
    using System.Collections.Generic;

    public class Box <T> : IBox<T>
    {
        private Stack<T> elements;

        public Box()
        {
            this.elements = new Stack<T>();
        }

        public void Add(T element)
        {
            this.elements.Push(element);
        }

        public T Remove()
        {
            return this.elements.Pop();
        }

        public int Count => this.elements.Count;
    }
}