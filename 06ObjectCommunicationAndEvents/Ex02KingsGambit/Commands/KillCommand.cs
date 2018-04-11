using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02KingsGambit.Commands
{

    public class KillCommand : Command
    {
        public KillCommand(Repository repo) : base(repo)
        {
        }

        public override void Execute(string data)
        {
            this.repo.RemoveFigure(data);
        }
    }
}
