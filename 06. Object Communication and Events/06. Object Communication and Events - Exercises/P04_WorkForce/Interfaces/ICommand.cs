namespace P04_WorkForce.Interfaces
{
    public interface ICommand
    {
        void Execute(params string[] data);
    }
}