namespace RecyclingStation.Tests
{
    using System.Linq;
    using Attributes;
    using Interfaces.WasteDisposal;
    using Models.GarbageDisposalStrategies;
    using NUnit.Framework;
    using WasteDisposal;

    [TestFixture]
    public class StrategyHolderTests
    {
        private IStrategyHolder strategyHolder;

        [SetUp]
        public void SetUp()
        {
            this.strategyHolder = new StrategyHolder();
        }

        [Test]
        public void GetDisposalStrategies_CollectionIsReadOnly()
        {
            var sh = new StrategyHolder();

            var strategiesType = sh.GetDisposalStrategies.GetType();
            var implementedInterfacesByCollection = ((System.Reflection.TypeInfo)strategiesType).ImplementedInterfaces;
            var implementIReadOnlyInterface = implementedInterfacesByCollection.Any(x => x.Name.Contains("IReadOnly"));

            Assert.That(implementIReadOnlyInterface);
        }

        [Test]
        public void AddSingleStrategy_Success()
        {
            var result = this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());

            Assert.That(this.strategyHolder.GetDisposalStrategies.Count, Is.EqualTo(1));
            Assert.That(result, Is.True);
        }

        [Test]
        public void AddSameStrategyTwiceFailed()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            var result = this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());

            Assert.That(this.strategyHolder.GetDisposalStrategies.Count, Is.EqualTo(1));
            Assert.That(result, Is.False);
        }

        [Test]
        public void AddMultipleStrategy_Success()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());

            Assert.That(this.strategyHolder.GetDisposalStrategies.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddMultipleSameStrategy_Success()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());

            Assert.That(this.strategyHolder.GetDisposalStrategies.Count, Is.EqualTo(3));
        }

        [Test]
        public void RemoveStrategy_Success()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());

            var result = this.strategyHolder.RemoveStrategy(typeof(StorableAttribute));

            Assert.That(this.strategyHolder.GetDisposalStrategies.Count, Is.EqualTo(2));
            Assert.That(result, Is.True);
        }

        [Test]
        public void RemoveMultipleStrategy_Success()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());

            this.strategyHolder.RemoveStrategy(typeof(StorableAttribute));
            this.strategyHolder.RemoveStrategy(typeof(RecyclableAttribute));

            Assert.That(this.strategyHolder.GetDisposalStrategies.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveMultipleSameStrategy_Success()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());

            this.strategyHolder.RemoveStrategy(typeof(StorableAttribute));
            var result = this.strategyHolder.RemoveStrategy(typeof(StorableAttribute));

            Assert.That(this.strategyHolder.GetDisposalStrategies.Count, Is.EqualTo(2));
            Assert.That(result, Is.False);
        }

        [Test]
        public void RemoveAllStrategy_Success()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());

            this.strategyHolder.RemoveStrategy(typeof(StorableAttribute));
            this.strategyHolder.RemoveStrategy(typeof(RecyclableAttribute));
            this.strategyHolder.RemoveStrategy(typeof(BurnableAttribute));

            Assert.That(this.strategyHolder.GetDisposalStrategies.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveFromEmptyStrategy_Failed()
        {
            var result = this.strategyHolder.RemoveStrategy(typeof(StorableAttribute));

            Assert.That(this.strategyHolder.GetDisposalStrategies.Count, Is.EqualTo(0));
            Assert.That(result, Is.False);
        }

        [Test]
        public void RemoveAllStrategyAndFromEmpty_Success()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());

            this.strategyHolder.RemoveStrategy(typeof(StorableAttribute));
            this.strategyHolder.RemoveStrategy(typeof(RecyclableAttribute));
            this.strategyHolder.RemoveStrategy(typeof(BurnableAttribute));
            var result = this.strategyHolder.RemoveStrategy(typeof(BurnableAttribute));

            Assert.That(this.strategyHolder.GetDisposalStrategies.Count, Is.EqualTo(0));
            Assert.That(result, Is.False);
        }

        [Test]
        public void RemoveMissingStrategy_Success()
        {
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());

            var result = this.strategyHolder.RemoveStrategy(typeof(BurnableAttribute));

            Assert.That(this.strategyHolder.GetDisposalStrategies.Count, Is.EqualTo(2));
            Assert.That(result, Is.False);
        }
    }
}