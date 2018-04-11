using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02KingsGambit.Contracts
{
  public  interface IFigure:IRespondable,INameable
    {
        string AttackReaction { get; }
    }
}
