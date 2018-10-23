namespace P07_InfernoInfinity.Models.Weapons
{
    using System.Collections.Generic;
    using System.Linq;
    using Attributes;
    using Interfaces;
    using WeaponMutators;

    [Info("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon : IWeapon
    {
        private const int STRENGTH_MIN_DAMAGE_MULTIPLIER = 2;
        private const int AGILITY_MIN_DAMAGE_MULTIPLIER = 1;
        private const int STRENGTH_MAX_DAMAGE_MULTIPLIER = 3;
        private const int AGILITY_MAX_DAMAGE_MULTIPLIER = 4;

        private readonly string name;
        private readonly int minDamage;
        private readonly int maxDamage;
        private readonly IGem[] sockets;
        private readonly LevelOfRarity levelOfRarity;

        protected Weapon(string name, int minDamage, int maxDamage, int numberOfSockets, LevelOfRarity levelOfRarity)
        {
            this.name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.sockets = new IGem[numberOfSockets];
            this.levelOfRarity = levelOfRarity;
        }

        public string Name => this.name;

        public int MinDamage => this.MinBaseDamage() + this.MinDamageFromGems();

        public int MaxDamage => this.MaxBaseDamage() + this.MaxDamageFromGems();

        public IEnumerable<IGem> NumberOfSockets => this.sockets;

        public LevelOfRarity LevelOfRarity => this.levelOfRarity;

        public void AddGem(IGem gem, int socketIndex)
        {
            if (socketIndex >= 0 && socketIndex < this.sockets.Length)
            {
                this.sockets[socketIndex] = gem;
            }
        }

        public void RemoveGem(int socketIndex)
        {
            if (socketIndex >= 0 && socketIndex < this.sockets.Length)
            {
                this.sockets[socketIndex] = null;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, +{this.TotalStrength()} Strength, +{this.TotalAgility()} Agility, +{this.TotalVitality()} Vitality";
        }

        private int MinBaseDamage()
        {
            var minBaseDamage = this.minDamage * (int) this.LevelOfRarity;
            return minBaseDamage;
        }

        private int MaxBaseDamage()
        {
            var maxBaseDamage = this.maxDamage * (int) this.LevelOfRarity;
            return maxBaseDamage;
        }

        private int TotalStrength()
        {
            var result = this.sockets
                .Where(x => x != null)
                .Select(x => x.Strength)
                .Sum();

            return result;
        }

        private int TotalAgility()
        {
            var result = this.sockets
                .Where(x => x != null)
                .Select(x => x.Agility)
                .Sum();

            return result;
        }

        private int TotalVitality()
        {
            var result = this.sockets
                .Where(x => x != null)
                .Select(x => x.Vitality)
                .Sum();

            return result;
        }

        private int MinDamageFromGems()
        {
            var minDamageFromGems = 0;

            minDamageFromGems += this.TotalStrength() * STRENGTH_MIN_DAMAGE_MULTIPLIER + 
                                 this.TotalAgility() * AGILITY_MIN_DAMAGE_MULTIPLIER;


            return minDamageFromGems;
        }

        private int MaxDamageFromGems()
        {
            var maxDamageFromGems = 0;

            maxDamageFromGems += this.TotalStrength() * STRENGTH_MAX_DAMAGE_MULTIPLIER + 
                                 this.TotalAgility() * AGILITY_MAX_DAMAGE_MULTIPLIER;

            return maxDamageFromGems;
        }
    }
}