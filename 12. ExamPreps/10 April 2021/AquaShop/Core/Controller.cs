namespace AquaShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Aquariums;
    using Models.Aquariums.Contracts;
    using Models.Decorations;
    using Models.Decorations.Contracts;
    using Models.Fish;
    using Models.Fish.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly DecorationRepository decorationRepository;
        private readonly IDictionary<string, IAquarium> aquariums;

        public Controller()
        {
            this.decorationRepository = new DecorationRepository();
            this.aquariums = new Dictionary<string, IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = aquariumType switch
            {
                "FreshwaterAquarium" => new FreshwaterAquarium(aquariumName),
                "SaltwaterAquarium" => new SaltwaterAquarium(aquariumName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType)
            };

            this.aquariums.Add(aquarium.Name, aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = decorationType switch
            {
                "Ornament" => new Ornament(),
                "Plant" => new Plant(),
                _ =>  throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType)
            };

            this.decorationRepository.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorationRepository.FindByType(decorationType);

            if (decoration is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            var aquarium = this.aquariums[aquariumName];

            aquarium.AddDecoration(decoration);
            this.decorationRepository.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = fishType switch
            {
                "FreshwaterFish" => new FreshwaterFish(fishName, fishSpecies, price),
                "SaltwaterFish" => new SaltwaterFish(fishName, fishSpecies, price),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidFishType)
            };

            var aquarium = this.aquariums[aquariumName];

            if ((fish is FreshwaterFish && aquarium is FreshwaterAquarium)
                || (fish is SaltwaterFish && aquarium is SaltwaterAquarium))
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            return string.Format(OutputMessages.UnsuitableWater);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums[aquariumName];
            aquarium.Feed();

            var count = aquarium.Fish.Count;
            return string.Format(OutputMessages.FishFed, count);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums[aquariumName];
            var aquariumValue = aquarium.Fish.Sum(f => f.Price)
                                + aquarium.Decorations.Sum(d => d.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, aquariumValue);
        }

        public string Report()
        {
            var reports = this.aquariums.Values.ToList()
                .Select(a => a.GetInfo());


            return string.Join(Environment.NewLine, reports);
        }
    }
}
