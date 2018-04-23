using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Tests
{

    private ProviderController controller;

    [SetUp]
    public void CreateInstance()
    {
        EnergyRepository energyRepo = new EnergyRepository();

        this.controller = new ProviderController(energyRepo);
    }
    
    [Test]
    public void ProvidersIncreasWhenRegister()
    {
        this.controller.Register(new List<string>() { "Standart", "15", "300" });

        Assert.AreEqual(1, controller.Entities.Count);
    }

    [Test]
    public void ProducingIncreasesTotalEnergyOutput()
    {
        this.controller.Register(new List<string>() { "Standart", "15", "300" });
        this.controller.Register(new List<string>() { "Standart", "20", "250" });

        string message = this.controller.Produce();

        Assert.AreEqual($"Produced {controller.TotalEnergyProduced} energy today!", message);
        Assert.AreEqual(550, this.controller.TotalEnergyProduced);
    }
    [Test]
    public void ProvidersAreDeletedWhenBroken()
    {
        this.controller.Register(new List<string>() { "Standart", "15", "300" });

        for (int i = 0; i < 11; i++)
        {
            this.controller.Produce();
        }

        Assert.AreEqual(0, controller.Entities.Count);
    }
    [Test]
    public void RegenerateIncreasesProviderDurability()
    {
        this.controller.Register(new List<string>() { "Standart", "15", "300" });
        this.controller.Register(new List<string>() { "Standart", "20", "250" });
        this.controller.Repair(100);
        for (int i = 0; i < 11; i++)
        {
            this.controller.Produce();
        }
        Assert.AreEqual(2, controller.Entities.Count);
    }
  
}

