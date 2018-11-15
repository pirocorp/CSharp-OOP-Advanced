namespace Travel.Core.Commands
{
    using System.Collections.Generic;
    using Controllers.Contracts;

    public class RegisterTripCommand : ICommand
    {
        private readonly IAirportController airportController;

        public RegisterTripCommand(IAirportController airportController)
        {
            this.airportController = airportController;
        }

        public string Execute(IList<string> args)
        {
            var source = args[0];
            var destination = args[1];
            var planeType = args[2];

            return this.airportController.RegisterTrip(source, destination, planeType);
        }
    }
}