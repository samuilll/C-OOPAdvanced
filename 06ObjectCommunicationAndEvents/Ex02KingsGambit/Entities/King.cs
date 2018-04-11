using Ex02KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02KingsGambit.Entities
{
   public class King:Figure
    {
        public King(string name) : base(name)
        {
        }

        public override string AttackReaction => "is under attack";

    }
}
