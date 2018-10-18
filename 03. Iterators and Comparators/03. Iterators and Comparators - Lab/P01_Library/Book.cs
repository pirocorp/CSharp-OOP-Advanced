namespace P01_Library
{
    using System;
    using System.Collections.Generic;

    public class Book : IComparable<Book>
    {
        private int year;
        private string title;
        private readonly List<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            this.Year = year;
            this.Title = title;
            this.authors = new List<string>(authors);
        }

        public string Title
        {
            get => this.title;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Title), $"{nameof(this.Title)} cannot be null or whitespace");
                }

                this.title = value;
            }
        }

        public int Year
        {
            get => this.year;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(this.Year)} cannot be negative.", nameof(this.Year));
                }

                this.year = value;
            }
        }

        public IEnumerable<string> Authors => this.authors;

        public int CompareTo(Book other)
        {
            var result = this.year.CompareTo(other.year);

            if (result == 0)
            {
                return this.Title.CompareTo(other.Title);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}