using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    protected AbstractCommand(IList<string> parameters, IHeroManager heroManager)
    {
        this.Parameters = parameters;
        this.HeroManager = heroManager;
    }

    public IList<string> Parameters { get; private set; }

    public IHeroManager HeroManager { get; private set; }

    public abstract string Execute();
}