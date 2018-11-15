namespace Travel.Entities.Airplanes
{
	public class LightAirplane : Airplane
	{
	    private const int SEATS = 5;
	    private const int BAGGAGE_COMPARTMENTS = 8;

        public LightAirplane()
			: base(SEATS, BAGGAGE_COMPARTMENTS)
		{
		}
	}
}