using System.Collections.Generic;

public interface IHeroManager
{
    string Quit();

    string AddHero(IList<string> parameters);

    string AddItemToHero(IList<string> parameters);

    string AddRecipeToHero(IList<string> parameters);

    string  Inspect(IList<string> parameters);
}