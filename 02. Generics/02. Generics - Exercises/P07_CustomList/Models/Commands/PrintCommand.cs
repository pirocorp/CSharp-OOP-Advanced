namespace P07_CustomList.Models.Commands
{
    using Interfaces;
    using IO.Interfaces;

    public class PrintCommand : Command
    {
        public PrintCommand(IWriter writer) : base(writer)
        {
        }

        public override void Execute(string[] inputParameters, ICustomList<string> listOfItems)
        {
            this.writer.WriteLine(listOfItems);

        }
    }
}