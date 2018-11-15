namespace Travel.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Controllers.Contracts;

    public class RegisterBagCommand : ICommand
    {
        private readonly IAirportController airportController;

        public RegisterBagCommand(IAirportController airportController)
        {
            this.airportController = airportController;
        }

        public string Execute(IList<string> args)
        {
            var username = args[0];
            var bagItems = args.Skip(1);

            return this.airportController.RegisterBag(username, bagItems);
        }
    }
}