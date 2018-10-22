namespace P03_BarraksWars.Core.Commands
{
    using Attributes;
    using Contracts;

    public class Retire : Command
    {
        [Inject]
        private readonly IRepository repository;

        public Retire(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            var unitType = this.Data[1];

            this.repository.RemoveUnit(unitType);

            return $"{unitType} retired!";
        }
    }
}