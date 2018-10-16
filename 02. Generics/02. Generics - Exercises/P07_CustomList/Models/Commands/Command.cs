namespace P07_CustomList.Models.Commands
{
    using Interfaces;
    using IO.Interfaces;

    public abstract class Command : ICommand
    {
        protected IWriter writer;

        protected Command(IWriter writer)
        {
            this.writer = writer;
        }

        public abstract void Execute(string[] inputParameters, ICustomList<string> listOfItems); //Command, params
    }
}