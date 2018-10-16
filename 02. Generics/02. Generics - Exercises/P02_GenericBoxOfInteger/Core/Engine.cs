namespace P02_GenericBoxOfInteger.Core
{
    using System.Collections.Generic;
    using IO.Interfaces;
    using Models;

    public class Engine
    {
        private List<Box<int>> intBoxes;

        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.intBoxes = new List<Box<int>>();

            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var n = int.Parse(this.reader.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var inputLine = int.Parse(this.reader.ReadLine());
                var currentBox = new Box<int>(inputLine);
                this.intBoxes.Add(currentBox);
            }

            foreach (var box in this.intBoxes)
            {
                this.writer.WriteLine(box.ToString());
            }
        }
    }
}