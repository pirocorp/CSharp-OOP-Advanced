namespace P03_BarraksWars.Core.Commands
{
    using Contracts;

    public class Report : Command
    {
        public Report(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            var output = this.Repository.Statistics;
            return output;
        }
    }
}