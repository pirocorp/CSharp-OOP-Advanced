namespace P04_WorkForce.Interfaces
{
    using Models;

    public interface IJob
    {
        string Name { get; }

        event EventHandler WorkIsDone;

        void Update();

        string ToString();
    }
}