namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using Interfaces;
    using Interfaces.Models;
    using Interfaces.Models.Wastes;

    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energyBalance = (garbage.VolumePerKg * garbage.Weight) * 0.8;
            var capitalBalance = 0;

            return new ProcessingData(energyBalance, capitalBalance);
        }
    }
}