namespace Easter.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Models.Bunnies;
    using Models.Bunnies.Contracts;
    using Models.Dyes;
    using Models.Eggs;
    using Models.Workshops;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly BunnyRepository bunnyRepository;
        private readonly EggRepository eggRepository;

        public Controller()
        {
            this.bunnyRepository = new BunnyRepository();
            this.eggRepository = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = bunnyType switch
            {
                "HappyBunny" => new HappyBunny(bunnyName),
                "SleepyBunny" => new SleepyBunny(bunnyName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType)
            };

            this.bunnyRepository.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            var bunny = this.bunnyRepository.FindByName(bunnyName);

            if (bunny is null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            var dye = new Dye(power);
            bunny.AddDye(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            var egg = new Egg(eggName, energyRequired);

            this.eggRepository.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            var bunnies = this.bunnyRepository.Models
                .Where(b => b.Energy >= 50)
                .OrderByDescending(b => b.Energy)
                .ToList();

            if (bunnies.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            var egg = this.eggRepository.FindByName(eggName);

            foreach (var currentBunny in bunnies)
            {
                var workshop = new Workshop();
                workshop.Color(egg, currentBunny);

                if (currentBunny.Energy == 0)
                {
                    this.bunnyRepository.Remove(currentBunny);
                }

                if (egg.IsDone())
                {
                    return string.Format(OutputMessages.EggIsDone, eggName);
                }
            }

            return string.Format(OutputMessages.EggIsNotDone, eggName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            var countColoredEggs = this.eggRepository.Models
                .Count(e => e.IsDone());

            sb.AppendLine($"{countColoredEggs} eggs are done!");
            sb.AppendLine("Bunnies info:");

            sb.AppendLine(string.Join(string.Empty, this.bunnyRepository.Models.Select(b => $"Name: {b.Name}\r\nEnergy: {b.Energy}\r\nDyes: {b.Dyes.Count(d => !d.IsFinished())} not finished\r\n")));

            return sb.ToString();
        }
    }
}
