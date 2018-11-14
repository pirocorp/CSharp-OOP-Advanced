using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private string mode;
    private readonly IEnergyRepository energyRepository;
    private readonly List<IHarvester> harvesters;
    private readonly IHarvesterFactory harvesterFactory;

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory harvesterFactory)
    {
        this.energyRepository = energyRepository;
        this.harvesterFactory = harvesterFactory;

        this.mode = Constants.DefaultMode;
        this.harvesters = new List<IHarvester>();
    }

    public double OreProduced { get; private set; }

    public string ChangeMode(string inputMode)
    {
        this.mode = inputMode;

        var reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChange, this.mode);
    }

    public string Produce()
    {
        double neededEnergy = 0;

        foreach (var harvester in this.harvesters)
        {
            if (this.mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 0.5;
            }
            else if (this.mode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * 0.2;
            }
        }

        //check if we can mine
        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            //mine
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.Produce();
            }
        }

        //take the mode in mind
        if (this.mode == "Energy")
        {
            minedOres = minedOres * 0.2;
        }
        else if (this.mode == "Half")
        {
            minedOres = minedOres * 0.5;
        }

        this.OreProduced += minedOres;

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string Register(IList<string> args)
    {
        var harvester = this.harvesterFactory.GenerateHarvester(args);
        this.harvesters.Add(harvester);
        
        return string.Format(Constants.SuccessfulRegistration, harvester.GetType().Name);
    }
}