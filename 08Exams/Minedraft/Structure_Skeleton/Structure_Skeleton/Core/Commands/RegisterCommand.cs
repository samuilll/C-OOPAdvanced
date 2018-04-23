using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class RegisterCommand:Command
    {
    private const string generateHarvester = "Harvester";

    private const string generateProvider = "Provider";

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IHarvesterController harvesterController, IProviderController providerController, IList<string> arguments)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string entity = this.Arguments[0];

        if (entity == generateHarvester)
        {
            return this.harvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else
        {
            return this.providerController.Register(this.Arguments.Skip(1).ToList());
        }
      
    }
}

