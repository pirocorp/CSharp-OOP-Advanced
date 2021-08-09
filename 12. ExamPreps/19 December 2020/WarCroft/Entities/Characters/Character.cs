using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
            }

            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;

            this.IsAlive = true;
        }

        public double AbilityPoints { get; }

        public bool IsAlive { get; set; }

        public string Name { get; }

        public IBag Bag { get; }

        public double Health
        {
            get => this.health;
            set => this.health = Math.Max(0, Math.Min(this.BaseHealth, value));
        }

        public double BaseHealth { get; }

        public double Armor
        {
            get => this.armor;
            set => this.armor = Math.Max(0, value);
        }

        public double BaseArmor { get; }

        public virtual void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            var hpDamage = hitPoints - this.Armor;
            this.Armor -= hitPoints;

            if (hpDamage > 0)
            {
                this.Health -= hpDamage;
            }

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public virtual void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}