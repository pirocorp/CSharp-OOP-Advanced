namespace BoatRacingSimulator.Interfaces
{
    public interface IBoat : IModelable
    {
        int EngineCount { get; }

        int Weight { get; }

        double CalculateRaceSpeed(IRace race);
    }
}