using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Test
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
        this.controller.Register(new List<string>() { "Standart", "20", "250" });

        Assert.AreEqual(2, controller.Entities.Count);
    }

    [Test]
    public void ProducingIncreasesTotalEnergyOutput()
    {
        this.controller.Register(new List<string>() { "Standart", "15", "300" });
        this.controller.Register(new List<string>() { "Standart", "20", "250" });

        string message = this.controller.Produce();

        Assert.AreEqual("Produced 550 energy today!", message);
    }
    [Test]
    public void ProvidersAreDeletedWhenBroken()
    {
        this.controller.Register(new List<string>() { "Standart", "15", "300" });
        this.controller.Register(new List<string>() { "Standart", "20", "250" });

        for (int i = 0; i < 11; i++)
        {
            this.controller.Produce();
        }
        this.controller.Register(new List<string>() { "Standart", "20", "250" });

        Assert.AreEqual(1, controller.Entities.Count);
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
        this.controller.Register(new List<string>() { "Standart", "20", "250" });

        Assert.AreEqual(3, controller.Entities.Count);
    }
    [Test]
    public void TotalEnergyProducedIncreasingWhenProduce()
    {
        this.controller.Register(new List<string>() { "Standart", "15", "300" });
        this.controller.Register(new List<string>() { "Standart", "20", "250" });


        this.controller.Produce();
        this.controller.Produce();


        Assert.AreEqual(1100, controller.TotalEnergyProduced);
    }
}

