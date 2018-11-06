namespace BoatRacingSimulator.Interfaces
{
    public interface IBoatFactory
    {
        IBoat CreateBoat(string boatModel, params object[] args);
    }
}