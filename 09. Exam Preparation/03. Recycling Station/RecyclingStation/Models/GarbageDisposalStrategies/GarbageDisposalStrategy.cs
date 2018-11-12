namespace RecyclingStation.Models.GarbageDisposalStrategies
{
    using Interfaces;
    using Interfaces.Models;
    using Interfaces.Models.GarbageDisposalStrategies;
    using Interfaces.Models.Wastes;

    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public abstract IProcessingData ProcessGarbage(IWaste garbage);
    }
}