namespace BoatRacingSimulator.Models.Boats
{
    using Interfaces;
    using Utility;

    public class RowBoat : Boat
    {
        private int oars;

        public RowBoat(string model, int weight, int oars) 
            : base(model, weight)
        {
            this.Oars = oars;
        }

        public int Oars
        {
            get => this.oars;

            private set
            {
                Validator.ValidatePropertyValue(value, nameof(this.Oars));
                this.oars = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            //(Oars * 100) - Boat Weight + Race Ocean Current Speed
            return this.Oars * 100D - this.Weight + race.OceanCurrentSpeed;
        }

        public override int EngineCount => 0;
    }
}