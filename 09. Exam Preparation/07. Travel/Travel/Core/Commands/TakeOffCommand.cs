namespace Travel.Core.Commands
{
    using System.Collections.Generic;
    using Controllers.Contracts;

    public class TakeOffCommand : ICommand
    {
        private readonly IFlightController flightController;

        public TakeOffCommand(IFlightController flightController)
        {
            this.flightController = flightController;
        }

        public string Execute(IList<string> args)
        {
            var output = this.flightController.TakeOff();
            return output;
        }
    }
}