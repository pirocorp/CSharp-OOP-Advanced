namespace BoatRacingSimulator.Models.Boats
{
    using Interfaces;
    using Utility;

    public abstract class Boat : IModelable, IBoat
    {
        private string model;
        private int weight;

        protected Boat(string model, int weight)
        {
            this.Model = model;
            this.Weight = weight;
        }

        public string Model
        {
            get => this.model;

            private set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatModelLength);
                this.model = value;
            }
        }

        public int Weight
        {
            get => this.weight;

            private set
            {
                Validator.ValidatePropertyValue(value, "Weight");
                this.weight = value;
            }
        }

        public abstract double CalculateRaceSpeed(IRace race);

        public abstract int EngineCount { get; }
    }
}