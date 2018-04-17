using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class Medium:Mission
    {
        private const double enduranceRequired = 50;
        private const double wearLevelDecrement = 50;
        private const string name = "Capturing dangerous criminals";

        public Medium(double scoreToComplete)
            : base(enduranceRequired, scoreToComplete, name, wearLevelDecrement)
        {
        }
    }

