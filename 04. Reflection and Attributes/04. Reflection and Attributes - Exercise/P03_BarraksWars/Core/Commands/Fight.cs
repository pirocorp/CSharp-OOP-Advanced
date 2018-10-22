namespace P03_BarraksWars.Core.Commands
{
    using System;
    using Contracts;

    public class Fight : Command
    {
        public Fight(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);

            return string.Empty;
        }
    }
}