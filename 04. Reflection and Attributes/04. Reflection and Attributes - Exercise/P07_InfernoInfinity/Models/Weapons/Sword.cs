namespace P07_InfernoInfinity.Models.Weapons
{
    using WeaponMutators;

    public class Sword : Weapon
    {
        private const int MIN_DAMAGE = 4;
        private const int MAX_DAMAGE = 6;
        private const int NUMBER_OF_SOCKETS = 3;

        public Sword(string name, LevelOfRarity levelOfRarity = LevelOfRarity.Common) 
            : base(name, MIN_DAMAGE, MAX_DAMAGE, NUMBER_OF_SOCKETS, levelOfRarity)
        {
        }
    }
}