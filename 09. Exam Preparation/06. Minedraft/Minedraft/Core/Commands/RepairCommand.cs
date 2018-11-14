using System.Collections.Generic;

public class RepairCommand : Command
{

    public RepairCommand(IList<string> arguments, IProviderController providerController)
        : base(arguments)
    {
        this.ProviderController = providerController;
    }

    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        var val = double.Parse(this.Arguments[0]);

        var result = this.ProviderController.Repair(val);
        return result;
    }
}