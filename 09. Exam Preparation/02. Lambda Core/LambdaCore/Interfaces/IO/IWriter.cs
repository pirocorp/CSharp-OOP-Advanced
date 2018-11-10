namespace LambdaCore.Interfaces.IO
{
    public interface IWriter
    {
        void WriteLine(object obj);

        void Write(object obj);
    }
}