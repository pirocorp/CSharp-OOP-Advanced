namespace Travel.Core.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Constants;
	using Contracts;
	using Entities;
	using Entities.Contracts;
	using Entities.Factories;
	using Entities.Factories.Contracts;

    public class AirportController : IAirportController
	{
	    private const int BAG_VALUE_CONFISCATION_THRESHOLD = 3000;

        private readonly IAirport airport;

		private readonly IAirplaneFactory airplaneFactory;
		private readonly IItemFactory itemFactory;

		public AirportController(IAirport airport)
		{
			this.airport = airport;
			this.airplaneFactory = new AirplaneFactory();
			this.itemFactory = new ItemFactory();
		}

	    public string RegisterPassenger(string username)
	    {
	        if (this.airport.GetPassenger(username) != null)
	        {
	            throw new InvalidOperationException(string.Format(Messages.PassengerAlreadyRegistered, username));
	        }

	        var passenger = new Passenger(username);

	        this.airport.AddPassenger(passenger);

	        return string.Format(Messages.RegisterPassenger, passenger.Username);
        }

	    public string RegisterBag(string username, IEnumerable<string> bagItems)
	    {
	        var passenger = this.airport.GetPassenger(username);

	        var items = bagItems.Select(i => this.itemFactory.CreateItem(i)).ToArray();
	        var bag = new Bag(passenger, items);

	        passenger.Bags.Add(bag);

	        return string.Format(Messages.RegisterBag, string.Join(", ", bagItems), username);
        }

	    public string RegisterTrip(string source, string destination, string planeType)
	    {
	        var airplane = this.airplaneFactory.CreateAirplane(planeType);
	        var trip = new Trip(source, destination, airplane);
	        this.airport.AddTrip(trip);

	        return string.Format(Messages.RegisterTrip, trip.Id);
        }

	    public string CheckIn(string username, string tripId, IEnumerable<int> bagCheckInIndices)
	    {

	        var passenger = this.airport.GetPassenger(username);
	        var trip = this.airport.GetTrip(tripId);

            //is already in any trips’ airplanes
            var checkedIn = this.airport.Trips.Any(t => t.Airplane.Passengers.Any(p => p.Username == username));
	        if (checkedIn)
	        {
	            throw new InvalidOperationException(string.Format(Messages.PassengerAlreadyCheckedIn, username));
	        }

	        var confiscatedBags = this.CheckInBags(passenger, bagCheckInIndices);
	        trip.Airplane.AddPassenger(passenger);

	        return string.Format(Messages.PassengerCheckedIn, passenger.Username,
	            bagCheckInIndices.Count() - confiscatedBags, bagCheckInIndices.Count());
        }

	    private int CheckInBags(IPassenger passenger, IEnumerable<int> bagsToCheckIn)
	    {
	        var bags = passenger.Bags;

	        var confiscatedBagCount = 0;
	        foreach (var i in bagsToCheckIn)
	        {
	            var currentBag = bags[i];
	            bags.RemoveAt(i);

	            if (currentBag.Items.Sum(x => x.Value) > BAG_VALUE_CONFISCATION_THRESHOLD)
	            {
	                this.airport.AddConfiscatedBag(currentBag);
	                confiscatedBagCount++;
	            }
	            else
	            {
	                this.airport.AddCheckedBag(currentBag);
	            }
	        }

	        return confiscatedBagCount;
	    }
    }
}