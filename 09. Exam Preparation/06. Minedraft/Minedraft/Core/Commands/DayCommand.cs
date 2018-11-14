using System;
using System.Collections.Generic;

public class DayCommand : Command
{
    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        var providersResult = this.ProviderController.Produce();
        var harvestersResult = this.HarvesterController.Produce();

        return $"{providersResult}{Environment.NewLine}{harvestersResult}";
    }
}