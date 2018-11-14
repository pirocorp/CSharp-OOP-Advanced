using System;

public abstract class Provider : IProvider
{
    private const double DEFAULT_DURABILITY = 1000;
    private const int DURABILITY_DECREASE = 100;

    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
        this.Durability = DEFAULT_DURABILITY;
    }

    public int Id { get; protected set; }

    public double EnergyOutput { get; protected set; }

    public double Durability
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
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}{Environment.NewLine}Durability: {this.Durability}" ;
    }
}