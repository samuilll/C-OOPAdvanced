using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class Hard:Mission
    {
        private const double enduranceRequired = 80;
        private const double wearLevelDecrement = 70;
        private const string name = "Disposal of terrorists";

        public Hard(double scoreToComplete)
            : base(enduranceRequired, scoreToComplete, name, wearLevelDecrement)
        {
        }
    }

