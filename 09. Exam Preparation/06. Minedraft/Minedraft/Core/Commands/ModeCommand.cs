using System.Collections.Generic;

public class ModeCommand : Command
{
    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController)
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public override string Execute()
    {
        var mode = this.Arguments[0];

        var result = this.HarvesterController.ChangeMode(mode);
        return result;
    }
}