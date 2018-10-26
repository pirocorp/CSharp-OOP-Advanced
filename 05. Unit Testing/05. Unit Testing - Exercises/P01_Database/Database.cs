namespace P01_Database
{
    using System;
    using System.Collections.Generic;

    public class Database
    {
        private const int DATABASE_DEFAULT_ARRAY_SIZE = 16;

        private readonly int[] data;
        private int currentIndex;

        public Database(params int[] inputData)
        {
            this.data = new int[DATABASE_DEFAULT_ARRAY_SIZE];
            this.currentIndex = 0;
            this.ProcessInputData(inputData);
        }

        public IReadOnlyCollection<int> Fetch
        {
            get
            {
                var result = new int[this.currentIndex];

                for (var i = 0; i < this.currentIndex; i++)
                {
                    result[i] = this.data[i];
                }

                return result;
            }
        }

        public void Add(int element)
        {
            if (this.currentIndex >= DATABASE_DEFAULT_ARRAY_SIZE)
            {
                throw new InvalidOperationException("Array is full.");
            }

            this.data[this.currentIndex++] = element;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty.");
            }

            this.data[--this.currentIndex] = default(int);
        }

        private void ProcessInputData(int[] inputData)
        {
            if (inputData == null)
            {
                return;
            }

            foreach (var element in inputData)
            {
                this.Add(element);
            }
        }
    }
}