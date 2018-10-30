namespace P02_KingsGambit.Interfaces
{
    public interface IUnit
    {
        bool IsAlive { get; }
        string Name { get; }

        void Kill();
        void RespondToAttack();
    }
}