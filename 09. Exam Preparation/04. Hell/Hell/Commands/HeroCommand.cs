using System;
using System.Collections.Generic;

public class HeroCommand : AbstractCommand
{
    public HeroCommand(IList<string> parameters, IHeroManager heroManager)
        : base(parameters, heroManager)
    {
    }

    public override string Execute()
    {
        return this.HeroManager.AddHero(this.Parameters);
    }
}