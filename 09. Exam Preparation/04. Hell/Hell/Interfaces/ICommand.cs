using System.Collections.Generic;

public interface ICommand
{
    IList<string> Parameters { get; }

    IHeroManager HeroManager { get; }

    string Execute();
}