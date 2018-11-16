namespace FestivalManager.Entities.Instruments
{
    using System;
    using Contracts;

    public abstract class Instrument : IInstrument
	{
	    private const int MAX_WEAR = 100;

        private double wear;

		protected Instrument()
		{
			this.Wear = MAX_WEAR;
		}

		public double Wear
		{
			get => this.wear;
		    private set => this.wear = Math.Min(Math.Max(value, 0), 100);
		}

		protected abstract int RepairAmount { get; }

	    public bool IsBroken => this.Wear <= 0;

	    public void WearDown() => this.Wear -= this.RepairAmount;

        public void Repair() => this.Wear += this.RepairAmount;
        
		public override string ToString()
		{
			var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

			return $"{this.GetType().Name} [{instrumentStatus}]";
		}
	}
}