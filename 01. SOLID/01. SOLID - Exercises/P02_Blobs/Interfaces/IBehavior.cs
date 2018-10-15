namespace _02.Blobs.Interfaces
{
    using Entities;

    public interface IBehavior
    {
        bool IsTriggered { get; }

        bool ToDelayRecurrentEffect { get; }

        void Trigger(Blob source);

        void ApplyRecurrentEffect(Blob source);
    }
}