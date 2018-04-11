using Ex02KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02KingsGambit.Entities
{
   public class RoyalGuard:Figure, IMortal
    {
        public RoyalGuard(string name) : base(name)
        {
            this.IsAlive=true;
        }

        public bool IsAlive { get; private set; }

        public override string AttackReaction => "is defending";

        public int HealthPoints { get; private set; } = 3;

        public void TakeDamage()
        {
            this.HealthPoints -= 1;

            if (this.HealthPoints <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}
