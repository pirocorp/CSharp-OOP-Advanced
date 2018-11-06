namespace BoatRacingSimulator.Models.Boats
{
    using Interfaces;

    public class PowerBoat : Boat
    {
        private readonly IBoatEngine firstEngine;
        private readonly IBoatEngine secondEngine;

        public PowerBoat(string model, int weight, IBoatEngine firstEngine, IBoatEngine secondEngine) 
            : base(model, weight)
        {
            this.firstEngine = firstEngine;
            this.secondEngine = secondEngine;
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            //(Engine 1 Output + Engine 2 Output) - Boat’s Weight + (Race Ocean Current Speed / 5);
            return (this.firstEngine.Output + this.secondEngine.Output) - this.Weight + (race.OceanCurrentSpeed / 5D);
        }

        public override int EngineCount => 2;
    }
}