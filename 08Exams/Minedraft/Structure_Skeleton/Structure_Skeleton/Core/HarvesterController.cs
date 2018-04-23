using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HarvesterController : IHarvesterController
{
    private const string fullMode = "Full";
    private const string halfMode = "Half";
    private const string energyMode = "Energy";

    private List<IHarvester> harvesters;
    private IHarvesterFactory harvesterFactory;
    private IEnergyRepository energyRepository;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.harvesterFactory = new HarvesterFactory();
        this.Mode = fullMode;
        this.OreProduced = 0;
    }
    public IReadOnlyList<IHarvester> Harvesters => (IReadOnlyList<IHarvester>)this.harvesters;

    public double OreProduced { get; private set; }

    public string Mode { get;private set; }

    public string ChangeMode(string mode)
    {
        this.Mode = mode;

        for (int i = 0; i < this.harvesters.Count; i++)
        {
            harvesters[i].Broke();

            if (harvesters[i].Durability<0)
            {
                harvesters.RemoveAt(i);
                i--;
            }
        }
        return string.Format(Constants.ChangeMode,mode);
    }

    public string Produce()
    {
        double neededEnergy = 0;

        foreach (var harvester in this.harvesters)
        {
            if (this.Mode == fullMode)
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.Mode == halfMode)
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.Mode == energyMode)
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        double minedOres = 0;

        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.Produce();
            }
        }

        if (this.Mode == energyMode)
        {
            minedOres = minedOres*20/100;
        }
        else if (this.Mode == halfMode)
        {
            minedOres = minedOres * 50 / 100;
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.OreOutputToday,minedOres);
    }

    public string Register(IList<string> args)
    {
        var harvester = this.harvesterFactory.GenerateHarvester(args);

        if (harvester!=null)
        {
            this.harvesters.Add(harvester);

            return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
        }

        return string.Empty;
    }
}

