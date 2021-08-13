namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int initialFishSize = 5;
        private const int increaseFishSizeStep = 2;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = initialFishSize;
        }

        public override void Eat()
        {
            this.Size += increaseFishSizeStep;
        }
    }
}
