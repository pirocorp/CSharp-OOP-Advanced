using System;

public class InfinityHarvester : Harvester
{
    private const int ORE_OUTPUT_DIVIDER = 10;
    private const int PERMANENT_DURABILITY = 1000;

    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= ORE_OUTPUT_DIVIDER;
    }

    public override double Durability
    {
        get => this.durability;
        protected set => this.durability = PERMANENT_DURABILITY;
    }
}