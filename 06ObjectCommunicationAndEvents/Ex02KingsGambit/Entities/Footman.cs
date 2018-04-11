using Ex02KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02KingsGambit.Entities
{
   public class Footman:Figure, IMortal
    {
        public Footman(string name) : base(name)
        {
            this.IsAlive = true;
        }

        public override string AttackReaction => "is panicking";

        public bool IsAlive { get; private set; }

        public int HealthPoints { get; private set; } = 2;

        public void TakeDamage()
        {
            this.HealthPoints -= 1;

            if (this.HealthPoints<=0)
            {
                this.IsAlive = false;
            }
        }
    }
}
