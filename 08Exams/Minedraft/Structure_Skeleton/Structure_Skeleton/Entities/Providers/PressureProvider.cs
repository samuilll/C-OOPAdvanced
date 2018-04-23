using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class PressureProvider:Provider
    {

    private const int durabilityDecrease = 500;
    private const int energuOutMultiplier = 2;

    public PressureProvider(int Id, double energyOutput) : base(Id, energyOutput)
    {
        this.EnergyOutput *= energuOutMultiplier;
    }
}

