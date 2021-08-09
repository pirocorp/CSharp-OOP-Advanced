namespace WarCroft.Entities.Characters
{
    using System;
    using Constants;
    using Contracts;
    using Inventory;

    public class Warrior : Character, IAttacker
    {
        private const double health = 100;
        private const double armor = 50;
        private const double abilityPoints = 40;

        // TODO: Finish warrior class.
        public Warrior(string name) 
            : base(name, health, armor, abilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (character.Equals(this))
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
