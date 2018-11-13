using System.Collections.Generic;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(IList<string> parameters, IHeroManager heroManager) 
        : base(parameters, heroManager)
    {
    }

    public override string Execute()
    {
        return this.HeroManager.AddRecipeToHero(this.Parameters);
    }
}