namespace P01_Library.IO.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string content);

        void WriteLine(object content);
    }
}
