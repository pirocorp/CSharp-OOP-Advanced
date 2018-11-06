namespace BoatRacingSimulator.Models.Boats
{
    using System;
    using Interfaces;
    using Utility;

    public class SailBoat : Boat
    {
        private int sailEfficiency;

        public SailBoat(string model, int weight, int sailEfficiency) 
            : base(model, weight)
        {
            this.SailEfficiency = sailEfficiency;
        }

        public int SailEfficiency
        {
            get => this.sailEfficiency;

            private set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException(Constants.IncorrectSailEfficiencyMessage);
                }

                this.sailEfficiency = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            //(Race Wind Speed * (Boat Sail Efficiency / 100)) – Boat’s Weight + (Race Ocean Current Speed / 2) 
            return race.WindSpeed * (this.SailEfficiency / 100D) - this.Weight + (race.OceanCurrentSpeed / 2D);
        }

        public override int EngineCount => 0;
    }
}