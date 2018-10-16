namespace P08_CustomListSorter.Models.Interfaces
{
    public interface ICommand
    {
        void Execute(string[] inputParameters, ICustomList<string> listOfItems);
    }
}
