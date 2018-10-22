namespace P03_BarraksWars.Core.Commands
{
    using Contracts;

    public class Retire : Command
    {
        public Retire(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var unitType = Data[1];

            this.Repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }
    }
}