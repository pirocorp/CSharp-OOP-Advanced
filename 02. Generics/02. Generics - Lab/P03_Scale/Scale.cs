namespace P03_Scale
{
    using System;

    public class Scale<T>
        where T : IComparable<T>
    {
        private T left;
        private T right;

        public Scale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public T GetHeavier()
        {
            var comparator = this.left.CompareTo(this.right);

            if (comparator > 0)
            {
                return this.left;
            }

            if (comparator < 0)
            {
                return this.right;
            }

            return default(T);
        }
    }
}