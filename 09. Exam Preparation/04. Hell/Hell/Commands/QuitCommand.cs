using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    public QuitCommand(IList<string> parameters, IHeroManager heroManager) 
        : base(parameters, heroManager)
    {
    }

    public override string Execute()
    {
        return this.HeroManager.Quit();
    }
}