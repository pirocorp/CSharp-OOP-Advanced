namespace P08_CustomListSorter.Models.Commands
{
    using Interfaces;
    using IO.Interfaces;

    public class AddCommand: Command
    {
        public AddCommand(IWriter writer) 
            : base(writer)
        {
        }

        public override void Execute(string[] inputParameters, ICustomList<string> listOfItems)
        {
            listOfItems.Add(inputParameters[1]); 
        }
    }
}