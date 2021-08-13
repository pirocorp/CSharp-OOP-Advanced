namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Decorations.Contracts;
    using Fish.Contracts;
    using Utilities.Messages;

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;

        private readonly IList<IDecoration> decorations;
        private readonly IDictionary<string, IFish> fishes;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.decorations = new List<IDecoration>();
            this.fishes = new Dictionary<string, IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.capacity = value;
            }
        }

        public int Comfort => this.Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations => new ReadOnlyCollection<IDecoration>(this.decorations);

        public ICollection<IFish> Fish => new ReadOnlyCollection<IFish>(this.fishes.Values.ToList());

        public void AddFish(IFish fish)
        {
            if (this.fishes.Count >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            
            this.fishes.Add(fish.Name, fish);
        }

        public bool RemoveFish(IFish fish) => this.fishes.Remove(fish.Name);

        public void AddDecoration(IDecoration decoration) => this.decorations.Add(decoration);

        public void Feed() => this.fishes.Values
            .ToList()
            .ForEach(f => f.Eat());

        public string GetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            var fishNames = this.Fish.Count == 0 
                ? "none" 
                : string.Join(", ", this.Fish.Select(f => f.Name));

            sb.AppendLine($"Fish: {fishNames}");
            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString();
        }
    }
}
