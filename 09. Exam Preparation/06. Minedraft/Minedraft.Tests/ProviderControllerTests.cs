using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class ProviderControllerTests
{
    private EnergyRepository energyRepository;
    private ProviderController providerController;

    [SetUp]
    public void SetupProviderController()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void ProducesCorrectAmountOfEnergy()
    {
        var p1 = new List<string>
        {
            "Solar","1", "100"
        };

        var p2 = new List<string>()
        {
            "Solar","2", "100"
        };

        this.providerController.Register(p1);
        this.providerController.Register(p2);

        for (int i = 0; i < 3; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(600));
    }

    [Test]
    public void ProducesNotBreakAtBellowZeroDurability()
    {
        var p1 = new List<string>
        {
            "Solar","1", "100"
        };

        var p2 = new List<string>()
        {
            "Solar","2", "100"
        };

        this.providerController.Register(p1);
        this.providerController.Register(p2);

        for (int i = 0; i < 16; i++)
        {
            this.providerController.Produce();
        }

        var result = this.providerController.Produce();

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(3200));
    }

    [Test]
    public void ProducesNotBreakAtBellowZeroDurabilityT()
    {
        var p1 = new List<string>
        {
            "Pressure","1", "100"
        };

        this.providerController.Register(p1);

        for (int i = 0; i < 16; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }

    [Test]
    public void RepaireProvider()
    {
        var p1 = new List<string>
        {
            "Pressure","1", "100"
        };

        this.providerController.Register(p1);

        for (int i = 0; i < 5; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.FirstOrDefault().Durability, Is.EqualTo(200));
        this.providerController.Repair(500);
        Assert.That(this.providerController.Entities.FirstOrDefault().Durability, Is.EqualTo(700));
    }
}