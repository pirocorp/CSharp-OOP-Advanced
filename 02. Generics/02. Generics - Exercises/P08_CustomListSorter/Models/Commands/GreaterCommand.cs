namespace P08_CustomListSorter.Models.Commands
{
    using Interfaces;
    using IO.Interfaces;

    public class GreaterCommand : Command
    {
        public GreaterCommand(IWriter writer) : base(writer)
        {
        }

        public override void Execute(string[] inputParameters, ICustomList<string> listOfItems)
        {
            this.writer.WriteLine(listOfItems.CountGreaterThan(inputParameters[1]));
        }
    }
}