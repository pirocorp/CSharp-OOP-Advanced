namespace P08_CustomListSorter.IO.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string content);

        void WriteLine(object content);
    }
}
