using System;

public abstract class Harvester : IHarvester
{
    private const int INITIAL_DURABILITY = 1000;
    private const int DURABILITY_DECREASE = 100;

    private double durability;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = INITIAL_DURABILITY;
    }

    public int Id { get; private set; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability
    {
        get => this.durability;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(Constants.BrokenEntity, this.GetType().Name, this.Id));
            }

            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= DURABILITY_DECREASE;
    }

    public double Produce()
    {
        return this.OreOutput;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}{Environment.NewLine}Durability: {this.Durability}";
    }
}