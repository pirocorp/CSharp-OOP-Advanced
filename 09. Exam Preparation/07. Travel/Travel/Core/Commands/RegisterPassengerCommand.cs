namespace Travel.Core.Commands
{
    using System.Collections.Generic;
    using Controllers.Contracts;

    public class RegisterPassengerCommand : ICommand
    {
        private readonly IAirportController airportController;

        public RegisterPassengerCommand(IAirportController airportController)
        {
            this.airportController = airportController;
        }

        public string Execute(IList<string> args)
        {
            var username = args[0];

            return this.airportController.RegisterPassenger(username);
        }
    }
}