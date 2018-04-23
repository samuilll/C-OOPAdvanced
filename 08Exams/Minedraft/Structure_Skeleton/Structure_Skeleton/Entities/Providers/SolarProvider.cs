using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  public  class SolarProvider:Provider
    {
    private const int durabilityIncrease = 500;
    public SolarProvider(int Id, double energyOutput) : base(Id, energyOutput)
    {
        this.Durability += durabilityIncrease;
    }
}

