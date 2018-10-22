namespace P03_BarraksWars.Core.Commands
{
    using Contracts;

    public class Add : Command
    {
        public Add(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var unitType = Data[1];
            var unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            var output = unitType + " added!";

            return output;
        }
    }
}