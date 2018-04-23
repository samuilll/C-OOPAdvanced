using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Ammunition : IAmmunition
{
    private const int WearMultiplier = 10;
    protected Ammunition(double weight)
    {
        this.Name = this.GetType().Name;
        this.Weight = weight;
        this.WearLevel = weight * 100;
    }

    public string Name { get;}

    public double Weight { get;}

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}

