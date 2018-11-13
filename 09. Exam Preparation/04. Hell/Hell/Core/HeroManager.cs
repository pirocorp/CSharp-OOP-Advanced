using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IHeroManager
{
    public readonly Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IList<string> arguments)
    {
        string result = null;

        var heroName = arguments[0];
        var heroType = arguments[1];

        try
        {
            var clazz = Type.GetType(heroType);
            var constructors = clazz.GetConstructors();
            var hero = (IHero) constructors[0].Invoke(new object[] {heroName});

            this.heroes.Add(hero.Name, hero);

            result = string.Format(Constants.HeroCreateMessage, hero.GetType().Name, hero.Name);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(IList<string> arguments)
    {
        var itemName = arguments[0];
        var heroName = arguments[1];
        var strengthBonus = int.Parse(arguments[2]);
        var agilityBonus = int.Parse(arguments[3]);
        var intelligenceBonus = int.Parse(arguments[4]);
        var hitPointsBonus = int.Parse(arguments[5]);
        var damageBonus = int.Parse(arguments[6]);

        var newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);
        this.heroes[heroName].AddItem(newItem);

        return string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
    }

    public string AddRecipeToHero(IList<string> arguments)
    {
        var recipeName = arguments[0];
        var heroName = arguments[1];
        var strengthBonus = int.Parse(arguments[2]);
        var agilityBonus = int.Parse(arguments[3]);
        var intelligenceBonus = int.Parse(arguments[4]);
        var hitPointsBonus = int.Parse(arguments[5]);
        var damageBonus = int.Parse(arguments[6]);

        var recipeItems = arguments.Skip(7).ToList();
        var newRecipe = new RecipeItem(recipeName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, recipeItems);
        this.heroes[heroName].AddRecipe(newRecipe);

        return string.Format(Constants.RecipeCreatedMessage, recipeName, heroName);
    }

    public string Inspect(IList<string> arguments)
    {
        var heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string Quit()
    {
        var orderedHeroes = this.heroes
            .Select(x => x.Value)
            .OrderByDescending(x => x.PrimaryStats)
            .ThenByDescending(x => x.SecondaryStats)
            .ToArray();

        var sb = new StringBuilder();

        var count = 1;
        foreach (var hero in orderedHeroes)
        {
            sb.AppendLine($"{count++}. {hero.GetType().Name}: {hero.Name}");
            sb.AppendLine($"###HitPoints: {hero.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Damage}");
            sb.AppendLine($"###Strength: {hero.Strength}");
            sb.AppendLine($"###Agility: {hero.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Intelligence}");

            if (hero.Items.Count == 0)
            {
                sb.AppendLine($"###Items: None");
                return sb.ToString().Trim();
            }

            sb.AppendLine($"###Items: {string.Join(", ", hero.Items.Select(x => x.Name).ToList())}");
        }

        return sb.ToString().Trim();
    }
}