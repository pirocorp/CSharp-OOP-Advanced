namespace BoatRacingSimulator.Models.BoatEngines
{
    using Interfaces;
    using Utility;

    public abstract class BoatEngine : IBoatEngine
    {
        private string model;
        private int horsepower;
        private int displacement;
        private readonly int multiplier;
        private int cachedOutput;

        protected BoatEngine(string model, int horsepower, int displacement, int multiplier)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.Displacement = displacement;
            this.multiplier = multiplier;
        }

        public int Output
        {
            get
            {
                if (this.cachedOutput != 0)
                {
                    return this.cachedOutput;
                }

                this.cachedOutput = (this.Horsepower * this.multiplier) + this.Displacement;
                return this.cachedOutput;
            }
        }

        public string Model
        {
            get => this.model;

            private set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatEngineModelLength);
                this.model = value;
            }
        }

        private int Horsepower
        {
            get => this.horsepower;

            set
            {
                Validator.ValidatePropertyValue(value, nameof(this.Horsepower));
                this.horsepower = value;
            }
        }

        private int Displacement
        {
            get => this.displacement;

            set
            {
                Validator.ValidatePropertyValue(value, nameof(this.Displacement));
                this.displacement = value;
            }
        }
    }
}
