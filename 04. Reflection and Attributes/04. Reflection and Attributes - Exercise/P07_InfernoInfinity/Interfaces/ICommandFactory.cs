using System.Collections.Generic;

namespace P07_InfernoInfinity.Interfaces
{
    public interface ICommandFactory
    {
        IExecutable CreateCommand(string commandType, string[] data, IDictionary<string, IWeapon> weapons);
    }
}
