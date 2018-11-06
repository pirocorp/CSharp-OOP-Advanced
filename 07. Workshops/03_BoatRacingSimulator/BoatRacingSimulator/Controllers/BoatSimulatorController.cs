namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Database;
    using Enumerations;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utility;
    using Models.BoatEngines;
    using Models.Boats;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        public BoatSimulatorController(BoatSimulatorDatabase database, IRace currentRace)
        {
            this.Database = database;
            this.CurrentRace = currentRace;
        }

        public BoatSimulatorController() : this(new BoatSimulatorDatabase(), null)
        {
        }

        public IRace CurrentRace { get; private set; }

        public BoatSimulatorDatabase Database { get; private set; }

        public string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            IBoatEngine engine;
            switch (engineType)
            {
                case EngineType.Jet:
                    engine = new JetBoatEngine(model, horsepower, displacement);
                    break;
                case EngineType.Sterndrive:
                    engine = new SterndriveBoatEngine(model, horsepower, displacement);
                    break;
                default:
                    throw new NotImplementedException();
            }

            this.Database.Engines.Add(engine);
            return
                $"Engine model {model} with {horsepower} HP and displacement {displacement} cm3 created successfully.";
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            IBoat boat = new RowBoat(model, weight, oars);
            this.Database.Boats.Add(boat);
            return $"Row boat with model {model} registered successfully.";
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            IBoat boat = new SailBoat(model, weight, sailEfficiency);
            this.Database.Boats.Add(boat);
            return $"Sail boat with model {model} registered successfully.";
        }

        public string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            var firstEngine = this.Database.Engines.GetItem(firstEngineModel);
            var secondEngine = this.Database.Engines.GetItem(secondEngineModel);
            IBoat boat = new PowerBoat(model, weight, firstEngine, secondEngine);
            this.Database.Boats.Add(boat);
            return $"Power boat with model {model} registered successfully.";
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            var engine = this.Database.Engines.GetItem(engineModel);
            var boat = new Yacht(model, weight, cargoWeight, engine);
            this.Database.Boats.Add(boat);
            return $"Yacht with model {model} registered successfully.";
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            this.ValidateRaceIsEmpty();
            this.CurrentRace = race;
            return
                $"A new race with distance {distance} meters, wind speed {windSpeed} m/s and ocean current speed {oceanCurrentSpeed} m/s has been set.";
        }

        public string SignUpBoat(string model)
        {
            var boat = this.Database.Boats.GetItem(model);
            this.ValidateRaceIsSet();
            if (!this.CurrentRace.AllowsMotorboats && boat.EngineCount > 0)
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }
            this.CurrentRace.AddParticipant(boat);
            return $"Boat with model {model} has signed up for the current Race.";
        }

        public string StartRace()
        {
            this.ValidateRaceIsSet();
            var participants = this.CurrentRace.GetParticipants();
            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var first = this.FindFastest(participants);
            participants.Remove(first.Value);
            var second = this.FindFastest(participants);
            participants.Remove(second.Value);
            var third = this.FindFastest(participants);
            participants.Remove(third.Value);

            var result = new StringBuilder();
            result.AppendLine(
                $"First place: {first.Value.GetType().Name} Model: {first.Value.Model} Time: {PrintFinishTime(first)}");
            result.AppendLine(
                $"Second place: {second.Value.GetType().Name} Model: {second.Value.Model} Time: {PrintFinishTime(second)}");
            result.Append(
                $"Third place: {third.Value.GetType().Name} Model: {third.Value.Model} Time: {PrintFinishTime(third)}");

            this.CurrentRace = null;

            return result.ToString();
        }

        private static string PrintFinishTime(KeyValuePair<double, IBoat> first)
        {
            if (first.Key < 0 || double.IsNaN(first.Key) || double.IsInfinity(first.Key))
            {
                return "Did not finish!";
            }
            else
            {
                var result = $"{first.Key:F2} sec";
                return result;
            }
        }

        public string GetStatistic()
        {
            var participants = this.CurrentRace.GetParticipants();
            var participantsCount = participants.Count;

            var participantsByBoatType = participants
                .GroupBy(
                    p => p.GetType().Name,
                    p => p,
                    (key, g) => new { BoatType = key, g.ToList().Count})
                .ToDictionary(x => x.BoatType, x => x.Count)
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            var sb = new StringBuilder();

            foreach (var participant in participantsByBoatType)
            {
                var percentage = (participant.Value /(double) participantsCount) * 100D; 
                sb.AppendLine($"{participant.Key} -> {percentage:F2}%");
            }

            return sb.ToString().Trim();
        }

        private KeyValuePair<double,IBoat> FindFastest(IList<IBoat> participants)
        {
            var positiveSpeedBoats = participants
                .Where(p => p.CalculateRaceSpeed(this.CurrentRace) > 0)
                .OrderByDescending(p => p.CalculateRaceSpeed(this.CurrentRace))
                .ToArray();

            var negativeOrZeroSpeedBoats = participants
                .Where(p => p.CalculateRaceSpeed(this.CurrentRace) <= 0)
                .ToArray();

            var first = positiveSpeedBoats.Length > 0 ? positiveSpeedBoats.First() : negativeOrZeroSpeedBoats.First();

            var speed = first.CalculateRaceSpeed(this.CurrentRace);
            var time = this.CurrentRace.Distance / speed;

            return new KeyValuePair<double, IBoat>(time, first);
        }

        private void ValidateRaceIsSet()
        {
            if (this.CurrentRace == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        private void ValidateRaceIsEmpty()
        {
            if (this.CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }
    }
}
