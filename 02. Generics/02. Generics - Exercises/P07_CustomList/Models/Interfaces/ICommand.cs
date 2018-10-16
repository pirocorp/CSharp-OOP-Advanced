namespace P07_CustomList.Models.Interfaces
{
    public interface ICommand
    {
        void Execute(string[] inputParameters, ICustomList<string> listOfItems);
    }
}
