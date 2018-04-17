using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public abstract class Mission:IMission
    {
        protected Mission(double enduranceRequired, double scoreToComplete, string name, double wearLevelDecrement)
        {
            this.EnduranceRequired = enduranceRequired;
            this.ScoreToComplete = scoreToComplete;
            this.Name = name;
            this.WearLevelDecrement = wearLevelDecrement;
        }

        public double EnduranceRequired { get; protected set; }
        public double ScoreToComplete { get; protected set; }

        public string Name { get; protected set; }

        public double WearLevelDecrement { get; protected set; }

    }

