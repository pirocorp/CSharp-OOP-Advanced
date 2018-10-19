namespace P08_PetClinic.IO.Interfaces
{
    public interface IWriter
    {
        void WriteLine(string content);

        void WriteLine(object content);
    }
}
