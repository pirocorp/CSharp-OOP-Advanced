namespace P03_GenericSwapMethodString.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IO.Interfaces;
    using Models;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;

        private List<Box<string>> listOfStrings;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            this.listOfStrings = new List<Box<string>>();
        }

        public void Run()
        {
            var n = int.Parse(this.reader.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var inputLine = this.reader.ReadLine();
                var currentBox = new Box<string>(inputLine);
                this.listOfStrings.Add(currentBox);
            }

            var inputTokens = this.reader.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var firstPosition = int.Parse(inputTokens[0]);
            var secondPosition = int.Parse(inputTokens[1]);

            this.listOfStrings = this.SwapElementsOnPositions(firstPosition, secondPosition, this.listOfStrings.ToArray()).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, this.listOfStrings));
        }

        private T[] SwapElementsOnPositions<T>(int position1, int position2, T[] listOfStrings)
        {
            var result = new T[listOfStrings.Length];

            var firstPosition = Math.Min(position1, position2);
            var secondPosition = Math.Max(position1, position2);

            var swappedElement = default(T);

            for (var i = 0; i < listOfStrings.Length; i++)
            {
                var source = listOfStrings[i];

                if (i == firstPosition)
                {
                    swappedElement = source;
                    result[i] = listOfStrings[secondPosition];
                    continue;
                }

                if (i == secondPosition)
                {
                    result[i] = swappedElement;
                    continue;
                }

                result[i] = source;
            }

            return result;
        }

    }
}