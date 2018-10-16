namespace P07_CustomList.IO.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string content);

        void WriteLine(object content);
    }
}
