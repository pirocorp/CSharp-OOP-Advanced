namespace RecyclingStation.Interfaces.Core
{
    public interface ICommandHandler
    {
        string ProcessGarbage(params string[] argsStrings);
        string Status();
    }
}