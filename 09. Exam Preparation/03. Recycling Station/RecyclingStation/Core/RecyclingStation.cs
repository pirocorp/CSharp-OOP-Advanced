namespace RecyclingStation.Core
{
    using Interfaces.Core;
    using Interfaces.Models;

    public class RecyclingStation : IRecyclingStation
    {
        public RecyclingStation()
        {
            this.EnergyBalance = 0;
            this.CapitalBalance = 0;
        }

        public double EnergyBalance { get; private set; }

        public double CapitalBalance { get; private set; }

        public void ApplyProcessingResult(IProcessingData result)
        {
            this.EnergyBalance += result.EnergyBalance;
            this.CapitalBalance += result.CapitalBalance;
        }
    }
}