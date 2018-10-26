namespace P02_ExtendedDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Database
    {
        private readonly IList<IPerson> peoples;

        public Database()
        {
            this.peoples = new List<IPerson>();
        }

        public void Add(IPerson person)
        {
            if (this.peoples.Any(x => x.Username == person.Username))
            {
                throw new InvalidOperationException("There is already person with such username.");
            }

            if (this.peoples.Any(x => x.Id == person.Id))
            {
                throw new InvalidOperationException("There is already person with such id.");
            }

            this.peoples.Add(person);
        }

        public void Remove()
        {
            if (this.peoples.Count == 0)
            {
                throw new InvalidOperationException("Database is empty.");
            }

            var lastIndex = this.peoples.Count - 1;
            this.peoples.RemoveAt(lastIndex);
        }

        public IPerson FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException(nameof(username), "Cannot search for empty username.");
            }

            var user = this.peoples.FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                throw new InvalidOperationException("No such username.");
            }

            return user;
        }

        public IPerson FindById(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), $"{nameof(id)} cannot be negative or zero.");
            }

            var user = this.peoples.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new InvalidOperationException("No such username.");
            }

            return user;
        }
    }
}