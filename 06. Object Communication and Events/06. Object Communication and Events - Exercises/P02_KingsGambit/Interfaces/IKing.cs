namespace P02_KingsGambit.Models
{
    public interface IKing
    {
        bool IsAlive { get; }
        string Name { get; }

        event KingUnderAttackEventHandler KingUnderAttack;

        void RespondToAttack();
    }
}