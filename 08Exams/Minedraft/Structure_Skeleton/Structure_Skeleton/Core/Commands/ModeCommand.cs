using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class ModeCommand:Command
    {
    private IHarvesterController harvesterController;

    public ModeCommand(IHarvesterController harvesterController, IList<string> arguments)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string mode = this.Arguments[0];
        return this.harvesterController.ChangeMode(mode);
    }
}

