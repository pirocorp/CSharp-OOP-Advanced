namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Dyes.Contracts;
    using Utilities.Messages;

    public abstract class Bunny : IBunny
    {
        private int energy;

        protected Bunny(string name, int energy)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
            }

            this.Name = name;
            this.Energy = energy;

            this.Dyes = new List<IDye>();
        }

        public string Name { get; }

        public int Energy
        {
            get => this.energy;
            protected set => this.energy = Math.Max(0, value);
        }

        public ICollection<IDye> Dyes { get; }

        public virtual void Work() => this.energy -= 10;

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }
    }
}
