namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Linq;
    using Attributes;
    using Interfaces.Models;
    using Interfaces.Models.Wastes;
    using Interfaces.WasteDisposal;

    public class GarbageProcessor : IGarbageProcessor
    {
        private IStrategyHolder strategyHolder;

        public GarbageProcessor()
            : this(new StrategyHolder())
        {
        }

        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public IStrategyHolder StrategyHolder
        {
            get => this.strategyHolder;
            private set => this.strategyHolder = value;
        }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            //Maybe doesn't working
            var type = garbage.GetType();
            var disposalAttribute = type.GetCustomAttributes(false).FirstOrDefault(a => a.GetType().IsSubclassOf(typeof(DisposableAttribute)));
            
            if (disposalAttribute == null || 
                !this.StrategyHolder.GetDisposalStrategies.TryGetValue(disposalAttribute.GetType(), out var currentStrategy))
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}