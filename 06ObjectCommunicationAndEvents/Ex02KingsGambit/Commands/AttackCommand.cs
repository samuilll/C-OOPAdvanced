using Ex02KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02KingsGambit.Commands
{
  public  class AttackCommand:Command
    {
        public AttackCommand(Repository repo):base(repo)
        {
        }

        public override void Execute(string data)
        {
            repo.Respond();
        }
    }
}
