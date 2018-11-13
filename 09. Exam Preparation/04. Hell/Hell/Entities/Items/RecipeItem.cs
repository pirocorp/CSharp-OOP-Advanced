using System.Collections.Generic;

public class RecipeItem : Item, IRecipe
{
    public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, 
        long hitPointsBonus, long damageBonus, IList<string> requiredItems) 
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.RequiredItems = new List<string>(requiredItems);
    }

    public IList<string> RequiredItems { get; private set; }
}