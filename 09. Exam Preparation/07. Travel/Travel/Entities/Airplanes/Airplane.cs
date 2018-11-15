namespace Travel.Entities.Airplanes
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using Entities.Contracts;

	public abstract class Airplane : IAirplane
    {
		private readonly List<IBag> baggageCompartment;
	    private readonly List<IPassenger> passengers;

		protected Airplane(int seats, int baggageCompartments)
		{
		    this.Seats = seats;
		    this.BaggageCompartments = baggageCompartments;

			this.baggageCompartment = new List<IBag>();
		    this.passengers = new List<IPassenger>();
        }

        public int Seats { get; private set; }

		public int BaggageCompartments { get; private set; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();

		public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

		public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public void AddPassenger(IPassenger passenger) 
	    {
			this.passengers.Add(passenger);
		}

		public IPassenger RemovePassenger(int passengerSeat)
		{
		    var removedPassenger = this.passengers[passengerSeat];

            this.passengers.RemoveAt(passengerSeat);

			return removedPassenger;
		}

		public IEnumerable<IBag>EjectPassengerBags(IPassenger passenger)
		{
			var passengerBags = this.baggageCompartment
				.Where(b => b.Owner == passenger)
				.ToArray();

			foreach (var bag in passengerBags)
				this.baggageCompartment.Remove(bag);

			return passengerBags;
		}

		public void LoadBag(IBag bag)
		{
			var isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;
			if (isBaggageCompartmentFull)
				throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");

			this.baggageCompartment.Add(bag);
		}
	}
}