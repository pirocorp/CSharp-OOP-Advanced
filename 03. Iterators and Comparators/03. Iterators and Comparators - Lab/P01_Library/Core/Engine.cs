namespace P01_Library.Core
{
    using System;
    using System.Collections.Generic;
    using IO.Interfaces;

    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            BookComparator bc = new BookComparator();

            Console.WriteLine(bc.Compare(bookOne, bookTwo) == -1);
            Console.WriteLine(bc.Compare(bookTwo, bookThree) == -1);
            Console.WriteLine(bc.Compare(bookThree, bookOne) == 1);
            Console.WriteLine(bc.Compare(bookOne, bookOne) == 0);
        }
    }
}