namespace Travel.Entities
{
    using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	
	public class Airport : IAirport
	{
	    private readonly List<IPassenger> passengers;
	    private readonly List<ITrip> trips;
	    private readonly List<IBag> checkedInBags;
        private readonly List<IBag> confiscatedBags;

	    public Airport()
	    {
	        this.passengers = new List<IPassenger>();
	        this.trips = new List<ITrip>();
	        this.checkedInBags = new List<IBag>();
	        this.confiscatedBags = new List<IBag>();
	    }

	    public IReadOnlyCollection<IBag> CheckedInBags => this.checkedInBags.AsReadOnly();

        public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBags.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public IReadOnlyCollection<ITrip> Trips => this.trips.AsReadOnly();

	    public void AddPassenger(IPassenger passenger)
	    {
	        this.passengers.Add(passenger);
	    }

	    public void AddTrip(ITrip trip)
	    {
            this.trips.Add(trip);
	    }

	    public void AddCheckedBag(IBag bag)
	    { 
            this.checkedInBags.Add(bag);
	    }

	    public void AddConfiscatedBag(IBag bag)
	    {
            this.confiscatedBags.Add(bag);
	    }

	    public IPassenger GetPassenger(string username)
	    {
	        var passenger = this.passengers.FirstOrDefault(p => p.Username == username);

	        return passenger;
	    }

	    public ITrip GetTrip(string id)
	    {
	        var trip = this.trips.FirstOrDefault(t => t.Id == id);

	        return trip;
	    }
    }
}