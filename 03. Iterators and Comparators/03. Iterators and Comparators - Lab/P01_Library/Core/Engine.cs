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

            var listOfBooks = new List<Book> { bookOne, bookTwo, bookThree };
            listOfBooks.Sort();

            Library libraryOne = new Library(bookOne, bookTwo, bookThree);
            Library libraryTwo = new Library(listOfBooks.ToArray());

            foreach (var book in libraryOne)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine();

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }
        }
    }
}