namespace P04_WorkForce.Interfaces
{
    using System.Collections.Generic;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandType, IList<IJob> jobs, IDictionary<string, IEmployee> employees);
    }
}