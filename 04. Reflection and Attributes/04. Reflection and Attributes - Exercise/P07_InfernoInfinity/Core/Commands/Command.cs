namespace P07_InfernoInfinity.Core.Commands
{
    using Interfaces;

    public abstract class Command : IExecutable
    {
        protected string[] Data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        public abstract void Execute();
    }
}