namespace BoatRacingSimulator.Models.Boats
{
    using Interfaces;
    using Utility;

    public class Yacht : Boat
    {
        private int cargoWeight;
        private readonly IBoatEngine engine;

        public Yacht(string model, int weight, int cargoWeight, IBoatEngine engine) 
            : base(model, weight)
        {
            this.CargoWeight = cargoWeight;
            this.engine = engine;
        }

        public int CargoWeight
        {
            get => this.cargoWeight;

            private set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            //Boat Engine Output - (Boat Weight + Cargo Weight) + (Race Ocean Current Speed / 2);
            return this.engine.Output - (this.Weight + this.CargoWeight) + (race.OceanCurrentSpeed / 2D);
        }

        public override int EngineCount => 1;
    }
}