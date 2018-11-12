namespace RecyclingStation.Models.Wastes
{
    using Interfaces.Models.Wastes;

    public abstract class Waste : IWaste
    {
        protected Waste(string name, double volumePerKg, double weight)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double VolumePerKg { get; private set; }

        public double Weight { get; private set; }
    }
}