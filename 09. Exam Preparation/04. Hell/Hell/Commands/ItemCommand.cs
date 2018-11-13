using System;
using System.Collections.Generic;

public class ItemCommand : AbstractCommand
{
    public ItemCommand(IList<string> parameters, IHeroManager heroManager) 
        : base(parameters, heroManager)
    {
    }

    public override string Execute()
    {
        return this.HeroManager.AddItemToHero(this.Parameters);
    }
}