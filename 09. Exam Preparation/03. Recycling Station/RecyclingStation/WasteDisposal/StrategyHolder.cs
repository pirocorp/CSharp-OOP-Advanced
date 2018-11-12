namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Collections.Generic;
    using Interfaces.Models.GarbageDisposalStrategies;
    using Interfaces.WasteDisposal;

    internal class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder()
        {
            this.strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
        }

        public IReadOnlyDictionary<Type,IGarbageDisposalStrategy> GetDisposalStrategies => 
            (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies;

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            if (this.strategies.ContainsKey(disposableAttribute))
            {
                return false;
            }

            this.strategies.Add(disposableAttribute, strategy);
            return true;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            if (this.strategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Remove(disposableAttribute);
                return true;
            }

            return false;
        }
    }
}