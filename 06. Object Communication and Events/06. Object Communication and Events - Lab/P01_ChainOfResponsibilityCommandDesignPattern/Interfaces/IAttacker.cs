namespace ObjectCommunicationAndEventsLab.Interfaces
{
    public interface IAttacker
    {
        void Attack();

        void SetTarget(ITarget newTarget);
    }
}
