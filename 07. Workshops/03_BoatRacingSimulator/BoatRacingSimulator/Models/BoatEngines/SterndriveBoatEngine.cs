namespace BoatRacingSimulator.Models.BoatEngines
{
    using Interfaces;

    public class SterndriveBoatEngine : BoatEngine, IModelable
    {
        private const int MULTIPLIER = 7;


        public SterndriveBoatEngine(string model, int horsepower, int displacement) 
            : base(model, horsepower, displacement, MULTIPLIER)
        {
        }
    }
}
