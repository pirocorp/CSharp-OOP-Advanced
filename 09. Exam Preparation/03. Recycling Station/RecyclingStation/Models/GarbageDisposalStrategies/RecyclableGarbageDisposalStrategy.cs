namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using Interfaces;
    using Interfaces.Models;
    using Interfaces.Models.Wastes;

    public class RecyclableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energyBalance = -((garbage.Weight * garbage.VolumePerKg) / 2);
            var capitalBalance = garbage.Weight * 400;

            return new ProcessingData(energyBalance, capitalBalance);
        }
    }
}