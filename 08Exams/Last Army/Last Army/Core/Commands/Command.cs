using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Command : ICommand
{
    protected Command(IReadOnlyList<string> arguments)
    {
        this.Arguments = arguments;
    }

    public IReadOnlyList<string> Arguments { get; }

    public abstract void Execute();
    
}

