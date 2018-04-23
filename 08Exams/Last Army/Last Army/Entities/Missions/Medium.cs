using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class Medium:Mission
    {
    private const double enduranceRequirement = 50;
    private const double wearDecrement = 50;
    private const double enduranceDecrement = 50;
    private const string name = "Capturing dangerous criminals";

    public Medium(double scoreToComplete)
        : base(name, enduranceRequirement, scoreToComplete, wearDecrement)
    {
    }

}

