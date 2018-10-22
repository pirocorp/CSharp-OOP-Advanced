namespace P07_InfernoInfinity.Interfaces
{
    public interface ICommandInterpreter
    {
        void InterpretCommand(string commandName, string[] data);
    }
}
