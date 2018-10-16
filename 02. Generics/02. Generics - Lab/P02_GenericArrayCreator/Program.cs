namespace P02_GenericArrayCreator
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var strings = ArrayCreator.Create(5, "Pesho");
            var integers = ArrayCreator.Create(10, 33);

        }
    }
}
