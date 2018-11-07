namespace BashSoft.DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using Contracts.DataStructures;
    using Contracts.DataStructures.SortingStrategies;
    using SortingStrategies;

    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T : IComparable<T>
    {
        private const int DEFAULT_SIZE = 16;

        private T[] innerCollection;
        private int size;
        private readonly IComparer<T> comparison;
        private readonly ISort<T> sortStrategy;

        public SimpleSortedList(IComparer<T> comparison, int capacity, ISort<T> sortStrategy)
        {
            this.comparison = comparison;
            this.InitializeInnerCollection(capacity);
            this.sortStrategy = sortStrategy;
        }

        public SimpleSortedList(IComparer<T> comparison, int capacity)
            : this(comparison, capacity, new QuickSort<T>())
        {
        }

        public SimpleSortedList(int capacity) 
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity, new QuickSort<T>())
        {
        }

        public SimpleSortedList(IComparer<T> comparison)
            : this(comparison, DEFAULT_SIZE, new QuickSort<T>())
        {
        }

        public SimpleSortedList()
            : this(DEFAULT_SIZE)
        {
        }

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.innerCollection = new T[capacity];
        }

        public int Size => this.size;

        public int Capacity => this.innerCollection.Length;

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (this.innerCollection.Length <= this.Size)
            {
                this.Resize();
            }

            this.innerCollection[this.Size] = element;
            this.size++;
            this.sortStrategy.Sort(this.innerCollection, 0, this.Size, this.comparison);
        }

        public void AddAll(ICollection<T> collection)
        {
            if (this.Size + collection.Count >= this.innerCollection.Length)
            {
                this.MultiResize(collection);
            }

            foreach (var element in collection)
            {
                if (element == null)
                {
                    throw new ArgumentNullException();
                }

                this.innerCollection[this.Size] = element;
                this.size++;
            }

            this.sortStrategy.Sort(this.innerCollection, 0, this.Size, this.comparison);
        }

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            var hasBeenRemoved = false;
            var indexOfRemovedElement = -1;

            for (var i = 0; i < this.Size; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfRemovedElement = i;
                    this.innerCollection[i] = default(T);
                    hasBeenRemoved = true;
                    break;
                }
            }

            if (hasBeenRemoved)
            {
                for (var i = indexOfRemovedElement; i < this.Size - 1; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                }

                this.innerCollection[this.Size - 1] = default(T);
                this.size--;
            }

            return hasBeenRemoved;
        }

        public string JoinWith(string joiner)
        {
            if (joiner == null)
            {
                throw new ArgumentNullException();
            }

            var sb = new StringBuilder();

            foreach (var element in this)
            {
                sb.Append(element);
                sb.Append(joiner);
            }

            sb.Remove(sb.Length - joiner.Length, joiner.Length);
            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            this.Resize(this.Size * 2);
        }

        private void MultiResize(ICollection<T> collection)
        {
            var newSize = this.innerCollection.Length * 2;

            while (this.Size + collection.Count >= newSize)
            {
                newSize *= 2;
            }

            this.Resize(newSize);
        }

        private void Resize(int newSize)
        {
            var newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.Size);
            this.innerCollection = newCollection;
        }
    }
}