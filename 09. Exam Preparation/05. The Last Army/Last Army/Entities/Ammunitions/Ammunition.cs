public abstract class Ammunition : IAmmunition
{
    private const int WEAR_LEVEL_MULTIPLIER = 100;

    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = weight * WEAR_LEVEL_MULTIPLIER;
    }

    public string Name { get; private set; }

    public double Weight { get; private set; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount) => this.WearLevel -= wearAmount;
}