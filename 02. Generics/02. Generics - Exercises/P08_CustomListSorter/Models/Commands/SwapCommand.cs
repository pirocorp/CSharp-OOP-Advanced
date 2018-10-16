namespace P08_CustomListSorter.Models.Commands
{
    using Interfaces;
    using IO.Interfaces;

    public class SwapCommand : Command
    {
        public SwapCommand(IWriter writer) : base(writer)
        {
        }

        public override void Execute(string[] inputParameters, ICustomList<string> listOfItems)
        {
            listOfItems.Swap(int.Parse(inputParameters[1]), int.Parse(inputParameters[2]));
        }
    }
}