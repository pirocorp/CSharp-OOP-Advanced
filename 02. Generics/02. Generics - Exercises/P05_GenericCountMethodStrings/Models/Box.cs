namespace P05_GenericCountMethodStrings.Models
{
    using System;

    public class Box<T> : IComparable, IComparable<Box<T>> where T : IComparable<T>
    {
        private readonly T element;

        public Box(T element)
        {
            this.element = element;
        }

        public int CompareTo(Box<T> other)
        {
            if (other == null)
            {
                throw new NullReferenceException("Cannot compare with null");
            }
                
            return this.element.CompareTo(other.element);
        }

        public override string ToString()
        {
            return $"{typeof(T).FullName}: {this.element}";
        }

        public int CompareTo(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                throw new ArgumentException($"Cannot compare with another type.");
            }
                
            return this.CompareTo(obj as Box<T>);
        }
    }
}