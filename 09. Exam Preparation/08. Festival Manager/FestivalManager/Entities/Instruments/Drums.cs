namespace FestivalManager.Entities.Instruments
{
	public class Drums : Instrument
	{
	    private const int REPAIR_AMOUNT = 20;

	    protected override int RepairAmount => REPAIR_AMOUNT;
	}
}
