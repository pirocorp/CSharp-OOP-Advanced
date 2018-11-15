namespace Travel.Entities
{
    using System.Collections.Generic;
    using Contracts;

    public class Passenger : IPassenger
    {
        private readonly IList<IBag> bags;

        public Passenger(string username)
        {
            this.Username = username;

            this.bags = new List<IBag>();
        }

        public string Username { get; }

        public IList<IBag> Bags => this.bags;
    }
}