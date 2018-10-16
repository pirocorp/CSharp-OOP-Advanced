namespace P06_GenericCountMethodDouble.Core
{
    using System;
    using System.Collections.Generic;
    using IO.Interfaces;
    using Models;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;

        private List<Box<double>> listOfStrings;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            this.listOfStrings = new List<Box<double>>();
        }

        public void Run()
        {
            var n = int.Parse(this.reader.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var inputLine = this.reader.ReadLine();
                var currentBox = new Box<double>(double.Parse(inputLine));
                this.listOfStrings.Add(currentBox);
            }

            var givenElement = new Box<double>(double.Parse(this.reader.ReadLine()));
            var arr = this.listOfStrings.ToArray();

            var result = this.CountNumberOfLargerElements(givenElement, arr);
            Console.WriteLine(result);
        }

        private int CountNumberOfLargerElements<T>(T givenElement, T[] array) where T : IComparable
        {
            var result = 0;

            foreach (var element in array)
            {
                if (element.CompareTo(givenElement) > 0)
                {
                    result++;
                }
            }

            return result;
        }
    }
}