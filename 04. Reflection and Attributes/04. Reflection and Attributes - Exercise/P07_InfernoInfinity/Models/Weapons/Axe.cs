namespace P07_InfernoInfinity.Models.Weapons
{
    using WeaponMutators;

    public class Axe : Weapon
    {
        private const int MIN_DAMAGE = 5;
        private const int MAX_DAMAGE = 10;
        private const int NUMBER_OF_SOCKETS = 4;

        public Axe(string name, LevelOfRarity levelOfRarity = LevelOfRarity.Common) 
            : base(name, MIN_DAMAGE, MAX_DAMAGE, NUMBER_OF_SOCKETS, levelOfRarity)
        {
        }
    }
}