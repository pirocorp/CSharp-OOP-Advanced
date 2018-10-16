namespace P07_CustomList.Models.Commands
{
    using Interfaces;
    using IO.Interfaces;

    public class MinCommand : Command
    {
        public MinCommand(IWriter writer) : base(writer)
        {
        }

        public override void Execute(string[] inputParameters, ICustomList<string> listOfItems)
        {
            this.writer.WriteLine(listOfItems.Min());
        }
    }
}