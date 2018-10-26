namespace P02_ExtendedDatabase.Interfaces
{
    public interface IPerson
    {
        long Id { get; }
        string Username { get; }
        string ToString();
    }
}