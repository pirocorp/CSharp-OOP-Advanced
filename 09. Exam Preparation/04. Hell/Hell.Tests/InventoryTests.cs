using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class InventoryTests
{
    private HeroInventory heroInventory;

    [SetUp]
    public void SetUp()
    {
        this.heroInventory = new HeroInventory();
    }

    private List<IItem> GetItemsFromHeroInventory()
    {
        var itemField = this.heroInventory
            .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(x => x.GetCustomAttributes(typeof(ItemAttribute), false).Any());

        var fieldValue = (Dictionary<string, /*List<*/IItem>)itemField.GetValue(this.heroInventory);

        return fieldValue.Select(x => x.Value).ToList();
    }

    private List<IRecipe> GetRecipesFromHeroInventory()
    {
        var itemField = this.heroInventory
            .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(x => x.Name == "recipeItems");

        var fieldValue = (Dictionary<string, /*List<*/IRecipe>)itemField.GetValue(this.heroInventory);

        return fieldValue.Select(x => x.Value).ToList();
    }

    [Test]
    public void AddCommonItemSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));

        var commonItemsCount = this.GetItemsFromHeroInventory().Count;

        Assert.That(commonItemsCount, Is.EqualTo(1));
    }

    [Test]
    public void AddCommonItemGetTotalStrengthBonusSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));

        Assert.That(this.heroInventory.TotalStrengthBonus, Is.EqualTo(1));
    }

    [Test]
    public void AddCommonItemGetTotalAgilityBonusSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));

        Assert.That(this.heroInventory.TotalAgilityBonus, Is.EqualTo(2));
    }

    [Test]
    public void AddCommonItemGetTotalIntelligenceBonusSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));

        Assert.That(this.heroInventory.TotalIntelligenceBonus, Is.EqualTo(3));
    }

    [Test]
    public void AddCommonItemGetTotalHitPointsBonusSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));

        Assert.That(this.heroInventory.TotalHitPointsBonus, Is.EqualTo(4));
    }

    [Test]
    public void AddCommonItemGetTotalDamageBonusSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));

        Assert.That(this.heroInventory.TotalDamageBonus, Is.EqualTo(5));
    }
    
    [Test]
    public void AddRecipeItemSuccessful()
    {
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 1, 2, 3, 4, 5, new List<string>()));

        var recipeItemsCount = this.GetRecipesFromHeroInventory().Count;

        Assert.That(recipeItemsCount, Is.EqualTo(1));
    }

    [Test]
    public void AddRecipeItemGetTotalStrengthBonusNotChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 10, 10, 10, 10, new List<string>(new []{"NotFound"})));

        Assert.That(this.heroInventory.TotalStrengthBonus, Is.EqualTo(1));
    }

    [Test]
    public void AddRecipeItemGetTotalTotalAgilityBonusNotChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 10, 10, 10, 10, new List<string>(new[] { "NotFound" })));

        Assert.That(this.heroInventory.TotalAgilityBonus, Is.EqualTo(2));
    }

    [Test]
    public void AddRecipeItemGetTotalIntelligenceBonusNotChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 10, 10, 10, 10, new List<string>(new[] { "NotFound" })));

        Assert.That(this.heroInventory.TotalIntelligenceBonus, Is.EqualTo(3));
    }

    [Test]
    public void AddRecipeItemGetTotalHitPointsBonusNotChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 10, 10, 10, 10, new List<string>(new[] { "NotFound" })));

        Assert.That(this.heroInventory.TotalHitPointsBonus, Is.EqualTo(4));
    }

    [Test]
    public void AddRecipeItemGetTotalDamageBonusNotChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 10, 10, 10, 10, new List<string>(new[] { "NotFound" })));

        Assert.That(this.heroInventory.TotalDamageBonus, Is.EqualTo(5));
    }

    [Test]
    public void AddRecipeItemGetTotalStrengthBonusChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item1", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item2", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 10, 10, 10, 10, new List<string>(new[] { "Item1", "Item2" })));

        Assert.That(this.heroInventory.TotalStrengthBonus, Is.EqualTo(11));
    }

    [Test]
    public void AddRecipeItemGetTotalTotalAgilityBonusChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item1", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item2", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 10, 10, 10, 10, new List<string>(new[] { "Item1", "Item2" })));

        Assert.That(this.heroInventory.TotalAgilityBonus, Is.EqualTo(12));
    }
    [Test]
    public void AddRecipeItemGetTotalTotalIntelligenceBonusChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item1", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item2", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 10, 10, 10, 10, new List<string>(new[] { "Item1", "Item2" })));

        Assert.That(this.heroInventory.TotalIntelligenceBonus, Is.EqualTo(13));
    }
    [Test]
    public void AddRecipeItemGetTotalTotalHitPointsBonusChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item1", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item2", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 10, 10, 10, 10, new List<string>(new[] { "Item1", "Item2" })));

        Assert.That(this.heroInventory.TotalHitPointsBonus, Is.EqualTo(14));
    }
    [Test]
    public void AddRecipeItemGetTotalTotalDamageBonusChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item1", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item2", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 10, 10, 10, 10, new List<string>(new[] { "Item1", "Item2" })));

        Assert.That(this.heroInventory.TotalDamageBonus, Is.EqualTo(15));
    }

    [Test]
    public void AddRecipeMultipleItemGetTotalStrengthBonusChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item1", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item2", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 0, 0, 0, 0, new List<string>(new[] { "Item1", "Item2" })));

        Assert.That(this.heroInventory.TotalStrengthBonus, Is.EqualTo(11));
        Assert.That(this.heroInventory.TotalAgilityBonus, Is.EqualTo(2));
        Assert.That(this.heroInventory.TotalIntelligenceBonus, Is.EqualTo(3));
        Assert.That(this.heroInventory.TotalHitPointsBonus, Is.EqualTo(4));
        Assert.That(this.heroInventory.TotalDamageBonus, Is.EqualTo(5));
    }

    [Test]
    public void AddRecipeMultipleItemGetTotalTotalAgilityBonusChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item1", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item2", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 0, 10, 0, 0, 0, new List<string>(new[] { "Item1", "Item2" })));

        Assert.That(this.heroInventory.TotalStrengthBonus, Is.EqualTo(1));
        Assert.That(this.heroInventory.TotalAgilityBonus, Is.EqualTo(12));
        Assert.That(this.heroInventory.TotalIntelligenceBonus, Is.EqualTo(3));
        Assert.That(this.heroInventory.TotalHitPointsBonus, Is.EqualTo(4));
        Assert.That(this.heroInventory.TotalDamageBonus, Is.EqualTo(5));
    }
    [Test]
    public void AddRecipeMultipleItemGetTotalTotalIntelligenceBonusChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item1", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item2", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 0, 0, 10, 0, 0, new List<string>(new[] { "Item1", "Item2" })));

        Assert.That(this.heroInventory.TotalStrengthBonus, Is.EqualTo(1));
        Assert.That(this.heroInventory.TotalAgilityBonus, Is.EqualTo(2));
        Assert.That(this.heroInventory.TotalIntelligenceBonus, Is.EqualTo(13));
        Assert.That(this.heroInventory.TotalHitPointsBonus, Is.EqualTo(4));
        Assert.That(this.heroInventory.TotalDamageBonus, Is.EqualTo(5));
    }
    [Test]
    public void AddRecipeMultipleItemGetTotalTotalHitPointsBonusChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item1", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item2", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 0, 0, 0, 10, 0, new List<string>(new[] { "Item1", "Item2" })));

        Assert.That(this.heroInventory.TotalStrengthBonus, Is.EqualTo(1));
        Assert.That(this.heroInventory.TotalAgilityBonus, Is.EqualTo(2));
        Assert.That(this.heroInventory.TotalIntelligenceBonus, Is.EqualTo(3));
        Assert.That(this.heroInventory.TotalHitPointsBonus, Is.EqualTo(14));
        Assert.That(this.heroInventory.TotalDamageBonus, Is.EqualTo(5));
    }
    [Test]
    public void AddRecipeMultipleItemGetTotalTotalDamageBonusChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item1", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item2", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 0, 0, 0, 0, 10, new List<string>(new[] { "Item1", "Item2" })));

        Assert.That(this.heroInventory.TotalStrengthBonus, Is.EqualTo(1));
        Assert.That(this.heroInventory.TotalAgilityBonus, Is.EqualTo(2));
        Assert.That(this.heroInventory.TotalIntelligenceBonus, Is.EqualTo(3));
        Assert.That(this.heroInventory.TotalHitPointsBonus, Is.EqualTo(4));
        Assert.That(this.heroInventory.TotalDamageBonus, Is.EqualTo(15));
    }

    [Test]
    public void AddRecipeMultipleItemGetTotalAllTotalBonusChangingSuccessful()
    {
        this.heroInventory.AddCommonItem(new CommonItem("CommonItem", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item1", 1, 2, 3, 4, 5));
        this.heroInventory.AddCommonItem(new CommonItem("Item2", 1, 2, 3, 4, 5));
        this.heroInventory.AddRecipeItem(new RecipeItem("RecipeItem", 10, 20, 30, 40, 50, new List<string>(new[] { "Item1", "Item2" })));

        Assert.That(this.heroInventory.TotalStrengthBonus, Is.EqualTo(11));
        Assert.That(this.heroInventory.TotalAgilityBonus, Is.EqualTo(22));
        Assert.That(this.heroInventory.TotalIntelligenceBonus, Is.EqualTo(33));
        Assert.That(this.heroInventory.TotalHitPointsBonus, Is.EqualTo(44));
        Assert.That(this.heroInventory.TotalDamageBonus, Is.EqualTo(55));
    }
}