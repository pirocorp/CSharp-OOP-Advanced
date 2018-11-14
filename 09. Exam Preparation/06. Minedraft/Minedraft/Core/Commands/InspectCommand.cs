using System.Collections.Generic;
using System.Linq;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        var id = int.Parse(this.Arguments[0]);
        var etity = this.HarvesterController.Entities.FirstOrDefault(e => e.Id == id);

        if (etity == null)
        {
            etity = this.ProviderController.Entities.FirstOrDefault(e => e.Id == id);
        }

        if (etity == null)
        {
            return string.Format(Constants.EntityNotFound, id);
        }

        return etity.ToString();
    }
}