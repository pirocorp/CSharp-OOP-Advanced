using System;

namespace WarCroft.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Constants;
    using Entities.Characters;
    using Entities.Characters.Contracts;
    using Entities.Items;

    public class WarController
    {
        private readonly ICollection<Character> characterParty;
        private readonly Stack<Item> itemsPool;

		public WarController()
        {
            this.characterParty = new List<Character>();
            this.itemsPool = new Stack<Item>();
        }

		public string JoinParty(string[] args)
        {
            var characterType = args[0];
            var name = args[1];

            var character = this.Factory<Character>(characterType, name);

            if (character is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            this.characterParty.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
        }

		public string AddItemToPool(string[] args)
		{
            var itemType = args[0];

            var item = this.Factory<Item>(itemType);

            if (item is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemType));
            }

            this.itemsPool.Push(item);
            return string.Format(SuccessMessages.AddItemToPool, itemType);
        }

		public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var character = this.GetCharacter(characterName);

            if (character is null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
            }

            if (!this.itemsPool.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            var item = this.itemsPool.Pop();
            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var character = this.GetCharacter(characterName);

            if (character is null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);
            }

            var itemName = args[1];

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, item.GetType().Name);
        }

		public string GetStats()
        {
            var characters = this.characterParty
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health);

            var sb = new StringBuilder();

            foreach (var character in characters)
            {
                sb.AppendLine(string.Format(
                    SuccessMessages.CharacterStats, 
                    character.Name, 
                    character.Health, 
                    character.BaseHealth, 
                    character.Armor, 
                    character.BaseArmor,
                    character.IsAlive ? "Alive" : "Dead"));
            }

            return sb.ToString();
        }

		public string Attack(string[] args)
        {
            var attackerName = args[0];
            var defenderName = args[1];

            var attacker = this.GetCharacter(attackerName);
            var defender = this.GetCharacter(defenderName);

            if (attacker is null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);
            }

            if (defender is null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, defenderName);
            }

            if (!(attacker is Warrior warrior))
            {
                throw new ArgumentException(ExceptionMessages.AttackFail, attackerName);
            }

            warrior.Attack(defender);

            var sb = new StringBuilder();

            sb.AppendLine(string.Format(
                SuccessMessages.AttackCharacter,
                attackerName,
                defenderName,
                attacker.AbilityPoints,
                defenderName,
                defender.Health,
                defender.BaseHealth,
                defender.Armor,
                defender.BaseArmor));

            if (!defender.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, defenderName));
            }

            return sb.ToString();
        }

		public string Heal(string[] args)
		{
            var healerName = args[0];
            var receiverName = args[1];

            var healer = this.GetCharacter(healerName);
            var receiver = this.GetCharacter(receiverName);

            if (healer is null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
            }

            if (receiver is null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, receiverName);
            }

            if (!(healer is Priest priest))
            {
                throw new ArgumentException(ExceptionMessages.HealerCannotHeal, healerName);
            }

            priest.Heal(receiver);

            return string.Format(
                SuccessMessages.HealCharacter, 
                healerName, 
                receiverName, 
                healer.AbilityPoints, 
                receiverName, 
                receiver.Health);
        }

        private T Factory<T>(string typeName, params object[] args)
            where T : class
        {
            var type = this
                .GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == typeName);

            if (type is null)
            {
                return null;
            }

            return (T)Activator.CreateInstance(type, args);
        }

        private Character GetCharacter(string characterName)
            => this.characterParty.FirstOrDefault(c => c.Name == characterName);
    }
}
