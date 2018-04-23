using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class Hard:Mission
    {
    private const double enduranceRequirement = 80;
    private const double wearDecrement = 70;
    private const double enduranceDecrement = 80;
    private const string name = "Disposal of terrorists";

    public Hard(double scoreToComplete)
        : base(name, enduranceRequirement, scoreToComplete, wearDecrement)
    {
    }

}

