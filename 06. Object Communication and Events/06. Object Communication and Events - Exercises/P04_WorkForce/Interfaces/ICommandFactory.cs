namespace P04_WorkForce.Interfaces
{
    using System.Collections.Generic;
    using Data;

    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandType, JobList jobs, IDictionary<string, IEmployee> employees);
    }
}