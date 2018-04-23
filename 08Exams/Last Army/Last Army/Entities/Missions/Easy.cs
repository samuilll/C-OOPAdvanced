using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class Easy:Mission
    {
    private const string name = "Suppression of civil rebellion";
    private const double enduranceRequirement = 20;
    private const double wearDecrement = 30;
    private const double enduranceDecrement = 20;

    public Easy(double scoreToComplete)
        :base(name,enduranceRequirement,scoreToComplete,wearDecrement)
    {
    }

}

