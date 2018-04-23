using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public  class ShutdownCommand:Command
    {

    private const string shutDown = "System Shutdown";
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IHarvesterController harvesterController, IProviderController providerController, IList<string> arguments)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine(shutDown);
        builder.AppendLine(string.Format(Constants.totalEnergyProduced, this.providerController.TotalEnergyProduced));
        builder.AppendLine(string.Format(Constants.totaloreProduced, this.harvesterController.OreProduced));

        return builder.ToString().Trim();

    }
}

