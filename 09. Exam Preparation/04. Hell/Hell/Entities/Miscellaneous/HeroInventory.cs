using System.Collections.Generic;
using System.Linq;

public class HeroInventory : IInventory
{
    [Item]
    private readonly List<IItem> commonItems;

    private readonly List<IRecipe> recipeItems;

    public HeroInventory()
    {
        this.commonItems = new List<IItem>();
        this.recipeItems = new List<IRecipe>();
    }

    public long TotalStrengthBonus => this.commonItems.Sum(i => i.StrengthBonus);

    public long TotalAgilityBonus => this.commonItems.Sum(i => i.AgilityBonus);

    public long TotalIntelligenceBonus => this.commonItems.Sum(i => i.IntelligenceBonus);

    public long TotalHitPointsBonus => this.commonItems.Sum(i => i.HitPointsBonus);

    public long TotalDamageBonus => this.commonItems.Sum(i => i.DamageBonus);

    public void AddCommonItem(IItem item)
    {
        this.commonItems.Add(item);
        this.CheckRecipes();
    }

    public void AddRecipeItem(IRecipe recipe)
    {
        this.recipeItems.Add(recipe);
        this.CheckRecipes();
    }

    private void CheckRecipes()
    {
        foreach (var recipe in this.recipeItems)
        {
            var requiredItems = new List<string>(recipe.RequiredItems);

            foreach (var commonItem in this.commonItems)
            {
                if (requiredItems.Contains(commonItem.Name))
                {
                    requiredItems.Remove(commonItem.Name);
                }
            }

            if (requiredItems.Count == 0)
            {
                this.CombineRecipe(recipe);
            }
        }
    }

    private void CombineRecipe(IRecipe recipe)
    {
        for (var i = 0; i < recipe.RequiredItems.Count; i++)
        {
            var itemName = recipe.RequiredItems[i];
            var item = this.commonItems.FirstOrDefault(x => x.Name == itemName);
            this.commonItems.Remove(item);
        }

        IItem newItem = new CommonItem(recipe.Name,
            recipe.StrengthBonus,
            recipe.AgilityBonus,
            recipe.IntelligenceBonus,
            recipe.HitPointsBonus,
            recipe.DamageBonus);

        this.commonItems.Add(newItem);
    }
}