using System;
using System.Collections.Generic;

public class InspectCommand : AbstractCommand
{
    public InspectCommand(IList<string> parameters, IHeroManager heroManager)
        : base(parameters, heroManager)
    {
    }

    public override string Execute()
    {
        return this.HeroManager.Inspect(this.Parameters);
    }
}