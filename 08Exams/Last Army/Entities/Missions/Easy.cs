using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Easy : Mission
    {
        private const double enduranceRequired = 20;
        private const double wearLevelDecrement = 30;
        private const string name = "Suppression of civil rebellion";

        public Easy(double scoreToComplete)
            : base(enduranceRequired, scoreToComplete, name, wearLevelDecrement)
        {
        }
    }

