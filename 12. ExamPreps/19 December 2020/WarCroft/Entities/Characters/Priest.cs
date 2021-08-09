namespace WarCroft.Entities.Characters
{
    using System;
    using Constants;
    using Contracts;
    using Inventory;

    public class Priest : Character, IHealer
    {
        private const double health = 50;
        private const double armor = 25;
        private const double abilityPoints = 40;

        public Priest(string name) 
            : base(name, health, armor, abilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            character.Health += this.AbilityPoints;
        }
    }
}
