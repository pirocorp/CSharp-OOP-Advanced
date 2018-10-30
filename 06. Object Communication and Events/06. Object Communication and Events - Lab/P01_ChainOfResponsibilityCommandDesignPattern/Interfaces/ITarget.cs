namespace ObjectCommunicationAndEventsLab.Interfaces
{
    public interface ITarget
    {
        void ReceiveDamage(int damage);

        bool IsDead { get; }

    }
}