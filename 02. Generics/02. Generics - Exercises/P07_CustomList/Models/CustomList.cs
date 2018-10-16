namespace P07_CustomList.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class CustomList<T> : ICustomList<T> where T : IComparable<T>
    {
        private readonly List<T> data;

        public CustomList()
        {
            this.data = new List<T>();
        }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove(int index)
        {
            var element = this.data[index];
            this.data.RemoveAt(index);

            return element;
        }

        public bool Contains(T element)
        {
            return this.data.Contains(element);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var swap = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = swap;
        }

        public int CountGreaterThan(T element)
        {
            return this.data.Count(e => e.CompareTo(element) > 0);
        }

        public T Max()
        {
            return this.data.Max();
        }

        public T Min()
        {
            return this.data.Min();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.data);
        }
    }
}