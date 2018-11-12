namespace RecyclingStation.Interfaces.Core
{
    using Models;

    public interface IRecyclingStation
    {
        double CapitalBalance { get; }
        double EnergyBalance { get; }

        void ApplyProcessingResult(IProcessingData result);
    }
}