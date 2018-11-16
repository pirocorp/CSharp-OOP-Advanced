namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int REPAIR_AMOUNT = 80;

        protected override int RepairAmount => REPAIR_AMOUNT;
    }
}
