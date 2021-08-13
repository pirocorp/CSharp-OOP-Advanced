namespace Easter.Models.Eggs
{
    using System;
    using Contracts;
    using Utilities.Messages;

    public class Egg : IEgg
    {
        private int energyRequired;

        public Egg(string name, int energyRequired)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.InvalidEggName);
            }

            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name { get; }

        public int EnergyRequired
        {
            get => this.energyRequired;
            private set => this.energyRequired = Math.Max(0, value);
        }

        public void GetColored()
        {
            this.EnergyRequired -= 10;
        }

        public bool IsDone() => this.energyRequired == 0;
    }
}
