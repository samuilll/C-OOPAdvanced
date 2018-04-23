public class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const double DecreaseDurability = 100;

    public Provider(int Id,double energyOutput)
    {
        EnergyOutput = energyOutput;
        ID = Id;
        this.Durability = InitialDurability;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= DecreaseDurability;

        if (this.Durability<0)
        {
            throw new System.Exception();
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public override string ToString()
    {
        return string.Format(string.Format(Constants.EntityToString, this.GetType().Name, this.Durability));
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}