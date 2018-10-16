namespace P08_CustomListSorter.Models.Commands
{
    using Interfaces;
    using IO.Interfaces;

    public class RemoveCommand : Command
    {
        public RemoveCommand(IWriter writer) : base(writer)
        {
        }

        public override void Execute(string[] inputParameters, ICustomList<string> listOfItems)
        {
            var result = listOfItems.Remove(int.Parse(inputParameters[1]));
            //this.writer.WriteLine(result);
        }
    }
}