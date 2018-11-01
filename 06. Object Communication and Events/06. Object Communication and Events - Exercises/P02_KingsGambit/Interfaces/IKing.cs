namespace P02_KingsGambit.Interfaces
{
    using Models;

    public interface IKing
    {
        bool IsAlive { get; }
        string Name { get; }

        event KingUnderAttackEventHandler KingUnderAttack;

        void OnKingUnderAttack();
    }
}