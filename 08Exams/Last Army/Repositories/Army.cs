using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Army : IArmy
    {

        private List<ISoldier> soldiers;

        public Army()
        {
            this.soldiers = new List<ISoldier>();
        }

        public IReadOnlyList<ISoldier> Soldiers => (IReadOnlyList<ISoldier>)soldiers;

        public void AddSoldier(ISoldier soldier)
        {
        this.soldiers.Add(soldier);
        }

        public void RegenerateTeam(string soldierType)
        {
        foreach (var soldier in this.Soldiers.Where(s => s.GetType().Name == soldierType))
        {
            soldier.Regenerate();
        }
    }
    }

