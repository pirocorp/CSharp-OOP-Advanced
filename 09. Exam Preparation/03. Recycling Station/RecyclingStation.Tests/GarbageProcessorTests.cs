namespace RecyclingStation.Tests
{
    using Attributes;
    using Interfaces.WasteDisposal;
    using Models.GarbageDisposalStrategies;
    using Models.Wastes;
    using NUnit.Framework;
    using WasteDisposal;

    [TestFixture]
    public class GarbageProcessorTests
    {
        private IStrategyHolder strategyHolder;
        private IGarbageProcessor garbageProcessor;

        [SetUp]
        public void Initialize()
        {
            this.strategyHolder = new StrategyHolder();
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableGarbageDisposalStrategy());
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableGarbageDisposalStrategy());

            this.garbageProcessor = new GarbageProcessor(this.strategyHolder);
        }

        [Test]
        public void EmptyConstructor_NotNullFieldStrategyHolder_Success()
        {
            var garbage = new GarbageProcessor();

            Assert.That(garbage.StrategyHolder, Is.Not.Null);
        }

        [Test]
        public void Constructor_NotNullFieldStrategyHolder_Success()
        {
            var holder = new StrategyHolder();
            var garbage = new GarbageProcessor(holder);

            Assert.That(garbage.StrategyHolder, Is.SameAs(holder));
        }

        [Test]
        public void ProcessWaste_RecyclableWaste_Success()
        {
            var garbage = new RecyclableWaste("GlassWaste", 10, 10);

            var result = this.garbageProcessor.ProcessWaste(garbage);

            Assert.That(result.CapitalBalance, Is.EqualTo(4000));
            Assert.That(result.EnergyBalance, Is.EqualTo(-50));
        }

        [Test]
        public void ProcessWaste_BurnableWaste_Success()
        {
            var garbage = new BurnableWaste("PaperWaste", 10, 10);

            var result = this.garbageProcessor.ProcessWaste(garbage);

            Assert.That(result.CapitalBalance, Is.EqualTo(0));
            Assert.That(result.EnergyBalance, Is.EqualTo(80));
        }

        [Test]
        public void ProcessWaste_StorableWaste_Success()
        {
            var garbage = new StorableWaste("NuclearWaste", 10, 10);

            var result = this.garbageProcessor.ProcessWaste(garbage);

            Assert.That(result.CapitalBalance, Is.EqualTo(-65));
            Assert.That(result.EnergyBalance, Is.EqualTo(-13));
        }

        [Test]
        public void ProcessWaste_SomeWaste_ThrowsException()
        {
            var holder = new StrategyHolder();
            var garbage = new GarbageProcessor(holder);

            var waste = new StorableWaste("NuclearWaste", 10, 10);

            Assert.That(() => garbage.ProcessWaste(waste), Throws.ArgumentException);
        }
    }
}
