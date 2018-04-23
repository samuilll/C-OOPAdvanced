using System;

public class InfinityHarvester : Harvester
{
    private const int OreOutputDivider = 10;
    private const double DecreaseDurability = 100;

    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= OreOutputDivider;
    }

    public override double Durability
    {
        get => this.durability;
        protected set => this.durability = Math.Max(0, value);
    }

    public override void Broke()
    {
        this.Durability -= DecreaseDurability;

        if (this.Durability<0)
        {
            this.Durability = 1000;
        }
    }
}