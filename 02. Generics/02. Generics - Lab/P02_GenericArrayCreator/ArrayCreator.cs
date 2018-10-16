namespace P02_GenericArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            var result = new T[length];

            for (var i = 0; i < length; i++)
            {
                result[i] = item;
            }

            return result;
        }
    }
}