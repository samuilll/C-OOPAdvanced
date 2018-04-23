using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class InspectCommand:Command
    {
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(IHarvesterController harvesterController, IProviderController providerController, IList<string> arguments)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var tempHarvCont = (HarvesterController)this.harvesterController;
        var tempProvCont = (ProviderController)this.providerController;

        int id = int.Parse(this.Arguments[0]);

        var harvester = tempHarvCont.Harvesters.FirstOrDefault(h => h.ID == id);

        var provider = tempProvCont.Entities.FirstOrDefault(h => h.ID == id);

        if (harvester!=null)
        {
            return harvester.ToString();
        }
        else if (provider!=null)
        {
            return provider.ToString();
        }

        return string.Format(Constants.NoEntityFound, id);
    }
}

