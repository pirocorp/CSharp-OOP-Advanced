namespace P08_CustomListSorter.Models.Commands
{
    using Interfaces;
    using IO.Interfaces;

    public class SortCommand : Command
    {
        public SortCommand(IWriter writer) : base(writer)
        {
        }

        public override void Execute(string[] inputParameters, ICustomList<string> listOfItems)
        {
            Sorter.Sort(listOfItems);
        }
    }
}