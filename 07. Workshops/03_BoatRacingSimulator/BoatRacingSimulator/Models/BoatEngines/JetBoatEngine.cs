namespace BoatRacingSimulator.Models.BoatEngines
{
    using Interfaces;

    public class JetBoatEngine : BoatEngine, IModelable
    {
        private const int MULTIPLIER = 5;

        public JetBoatEngine(string model, int horsepower, int displacement) 
            : base(model, horsepower, displacement, MULTIPLIER)
        {
        }
    }
}