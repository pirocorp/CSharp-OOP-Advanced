namespace Travel.Core.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Controllers.Contracts;

    public class CheckInCommand : ICommand
    {
        private readonly IAirportController airportController;

        public CheckInCommand(IAirportController airportController)
        {
            this.airportController = airportController;
        }

        public string Execute(IList<string> args)
        {
            var username = args[0];
            var tripId = args[1];
            var bagCheckInIndices = args.Skip(2).Select(int.Parse).ToArray();

            return this.airportController.CheckIn(username, tripId, bagCheckInIndices);
        }
    }
}