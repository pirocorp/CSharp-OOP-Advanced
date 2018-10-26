namespace P02_ExtendedDatabase
{
    using System;
    using Interfaces;

    public class Person : IPerson
    {
        private long id;
        private string username;

        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id
        {
            get => this.id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Id), $"{nameof(this.Id)} cannot be negative or zero.");
                }

                this.id = value;
            }
        }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(this.Username)} cannot be empty.", nameof(this.Username));
                }

                this.username = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.Username}";
        }
    }
}