namespace P07_InfernoInfinity.Interfaces
{
    using System.Collections.Generic;
    using Models.Weapons.WeaponMutators;

    public interface IWeapon
    {
        string Name { get; }

        int MinDamage { get; }

        int MaxDamage { get; }

        IEnumerable<IGem> NumberOfSockets { get; }

        LevelOfRarity LevelOfRarity { get; }

        void AddGem(IGem gem, int socketIndex);

        void RemoveGem(int socketIndex);
    }
}