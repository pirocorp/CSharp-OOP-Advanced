namespace RecyclingStation.Models.Wastes
{
    using Attributes;

    [Recyclable]
    public class RecyclableWaste : Waste
    {
        public RecyclableWaste(string name, double volumePerKg, double weight) 
            : base(name, volumePerKg, weight)
        {
        }
    }
}