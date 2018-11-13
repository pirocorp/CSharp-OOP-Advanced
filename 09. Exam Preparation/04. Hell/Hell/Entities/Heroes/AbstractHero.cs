using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero, IComparable<AbstractHero>
{
    private readonly IInventory inventory;
    private readonly long strength;
    private readonly long agility;
    private readonly long intelligence;
    private readonly long hitPoints;
    private readonly long damage;

    protected AbstractHero(string name, long strength, long agility, long intelligence, long hitPoints, long damage)
        : this(name, strength, agility, intelligence, hitPoints, damage, new HeroInventory())
    {
    }

    protected AbstractHero(string name, long strength, long agility, long intelligence, long hitPoints, long damage, IInventory inventory)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = inventory;
    }

    public string Name { get; private set; }

    public long Strength => this.strength + this.inventory.TotalStrengthBonus;

    public long Agility => this.agility + this.inventory.TotalAgilityBonus;

    public long Intelligence => this.intelligence + this.inventory.TotalIntelligenceBonus;

    public long HitPoints => this.hitPoints + this.inventory.TotalHitPointsBonus;

    public long Damage => this.damage + this.inventory.TotalDamageBonus;

    public long PrimaryStats => this.Strength + this.Agility + this.Intelligence;

    public long SecondaryStats => this.HitPoints + this.Damage;

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            var itemField = this.inventory
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(ItemAttribute), false).Any());

            var fieldValue = (List<IItem>)itemField.GetValue(this.inventory);

            return fieldValue;
        }
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public void AddItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public int CompareTo(AbstractHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);

        if (primary != 0)
        {
            return primary;
        }

        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}");
        sb.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        sb.AppendLine($"Strength: {this.Strength}");
        sb.AppendLine($"Agility: {this.Agility}");
        sb.AppendLine($"Intelligence: {this.Intelligence}");

        if (this.Items.Count == 0)
        {
            sb.AppendLine($"Items: None");
            return sb.ToString();
        }

        sb.AppendLine($"Items: ");

        foreach (var item in this.Items)
        {
            sb.AppendLine(item.ToString());
        }

        return sb.ToString().Trim();
    }
}