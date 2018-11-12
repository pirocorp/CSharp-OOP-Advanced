namespace RecyclingStation.Models.Wastes
{
    using Attributes;

    [Burnable]
    public class BurnableWaste : Waste
    {
        public BurnableWaste(string name, double volumePerKg, double weight) 
            : base(name, volumePerKg, weight)
        {
        }
    }
}