namespace P01_Library
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] inputBooks)
        {
            this.books = new List<Book>(inputBooks);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return this.books.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}