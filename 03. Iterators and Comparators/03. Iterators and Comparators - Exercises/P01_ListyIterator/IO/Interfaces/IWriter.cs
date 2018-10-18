namespace P01_ListyIterator.IO.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string content);

        void WriteLine(object content);
    }
}
