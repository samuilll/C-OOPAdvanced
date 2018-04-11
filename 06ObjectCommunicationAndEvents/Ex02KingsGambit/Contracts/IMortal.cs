using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02KingsGambit.Contracts
{
   public interface IMortal
    {
        bool IsAlive { get; }

        void TakeDamage();

        int HealthPoints { get; }
    }
}
