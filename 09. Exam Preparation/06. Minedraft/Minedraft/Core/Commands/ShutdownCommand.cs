using System;
using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine(Constants.SystemShutdown);
        sb.AppendLine(string.Format(Constants.TotalProducedEnergy, this.ProviderController.TotalEnergyProduced));
        sb.Append(string.Format(Constants.TotalProducedOre, this.HarvesterController.OreProduced));

        return sb.ToString();
    }
}