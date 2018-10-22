namespace P03_BarraksWars.Core.Commands
{
    using Attributes;
    using Contracts;

    public class Add : Command
    {
        [Inject]
        private readonly IRepository repository;
        [Inject]
        private readonly IUnitFactory unitFactory;

        public Add(string[] data/*, IRepository repository, IUnitFactory unitFactory*/) 
            : base(data/*, repository, unitFactory*/)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public override string Execute()
        {
            var unitType = Data[1];
            var unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            var output = unitType + " added!";

            return output;
        }
    }
}