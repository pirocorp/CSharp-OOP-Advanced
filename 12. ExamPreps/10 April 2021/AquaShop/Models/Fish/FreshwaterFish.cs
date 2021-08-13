namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int initialFishSize = 3;
        private const int increaseFishSizeStep = 3;

        public FreshwaterFish(string name, string species, decimal price) 
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
