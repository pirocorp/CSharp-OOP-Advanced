namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using Interfaces.Models;
    using Interfaces.Models.Wastes;

    public class StorableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energyBalance = -((garbage.Weight * garbage.VolumePerKg) * 0.13);
            var capitalBalance = -((garbage.Weight * garbage.VolumePerKg) * 0.65);
            
            return new ProcessingData(energyBalance, capitalBalance);
        }
    }
}