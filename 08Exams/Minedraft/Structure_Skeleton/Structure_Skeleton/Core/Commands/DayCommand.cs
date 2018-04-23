using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class DayCommand:Command
    {

    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public DayCommand(IHarvesterController harvesterController,IProviderController providerController, IList<string> arguments)
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine(this.providerController.Produce());
        builder.AppendLine(this.harvesterController.Produce());

        return builder.ToString().Trim();     
    }
}

