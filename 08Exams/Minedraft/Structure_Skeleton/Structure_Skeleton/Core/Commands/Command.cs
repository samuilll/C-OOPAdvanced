using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public abstract class Command : ICommand
    {

    public Command(IList<string> arguments)
        {
            this.Arguments = arguments;
        }

        public IList<string> Arguments { get; }

        public virtual string Execute()
        {
            throw new NotImplementedException();
        }
    }

