using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02KingsGambit.Commands
{
    public abstract class Command : IExecutable
    {

        protected Repository repo;

        protected Command(Repository repo)
        {
            this.repo = repo;
        }

        public virtual void Execute(string data)
        {
            throw new NotImplementedException();
        }
    }
}
