namespace Travel.Entities.Airplanes
{
	public class MediumAirplane : Airplane
	{
	    private const int SEATS = 10;
	    private const int BAGGAGE_COMPARTMENTS = 14;

        public MediumAirplane()
			: base(SEATS, BAGGAGE_COMPARTMENTS)
		{
		}
	}
}