namespace P07_InfernoInfinity.Core.Factories
{
    using System;
    using Interfaces;
    using Models.Weapons.WeaponMutators;

    public class WeaponFactory : Factory<IWeapon>
    {
        public override IWeapon Create(string[] inputParameters)
        {
            var tokens = inputParameters[0].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var weaponType = tokens[1];

            var name = inputParameters[1];
            var levelOfRarityString = tokens[0];
            var levelOfRarity = Enum.Parse<LevelOfRarity>(levelOfRarityString);

            return base.Create(weaponType, new object[] { name, levelOfRarity });
        }
    }
}