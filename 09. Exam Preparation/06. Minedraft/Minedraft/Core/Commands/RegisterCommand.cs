using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        //Harvester Sonic {id} {oreOutput} {energyRequirement}
        //Provider Hammer {id}{energyOutput}

        //TODO Instate if-else use reflection

        var entityType = this.Arguments[0];

        var result = string.Empty;

        if (entityType == nameof(Harvester))
        {
            result = this.HarvesterController.Register(this.Arguments.Skip(1).ToList());
        }
        else if(entityType == nameof(Provider))
        {
            result = this.ProviderController.Register(this.Arguments.Skip(1).ToList());
        }

        return result;
    }
}