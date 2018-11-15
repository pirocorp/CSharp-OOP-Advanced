namespace Travel.Entities
{
	using Airplanes.Contracts;
	using Contracts;

	public class Trip : ITrip
	{
		private static int _id = 1;

		public Trip(string source, string destination, IAirplane airplane)
		{
			this.Source = source;
			this.Destination = destination;
			this.Airplane = airplane;
		    this.IsCompleted = false;

			this.Id = GenerateId(source, destination);
		}

		public string Id { get; private set; }

		public string Source { get; private set; }

        public string Destination { get; private set; }

        public bool IsCompleted { get; private set; }

		public IAirplane Airplane { get; }

		public void Complete() => this.IsCompleted = true;

		private static string GenerateId(string departure, string destination)
		{
			return $"{departure}{destination}{_id++}";
		}
	}
}