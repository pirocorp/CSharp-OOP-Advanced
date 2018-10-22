namespace P03_BarraksWars.Core.Commands
{
    using Attributes;
    using Contracts;

    public class Report : Command
    {
        [Inject]
        private readonly IRepository repository;

        public Report(string[] data/*, IRepository repository, IUnitFactory unitFactory*/) 
            : base(data/*, repository, unitFactory*/)
        {
        }

        public override string Execute()
        {
            var output = this.repository.Statistics;
            return output;
        }
    }
}