namespace P04_WorkForce.Core.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Interfaces;
    using Models.Commands;
    using Models.Employees;

    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandType, IList<IJob> jobs, IDictionary<string, IEmployee> employees)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == $"{commandType}Command");

            if (type == null)
            {
                type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name.Contains($"{commandType}"));
            }

            if (type == null)
            {
                throw new NotSupportedException($"Not supported Employee type: {commandType}");
            }

            if (type.IsSubclassOf(typeof(Employee)))
            {
                if (!(Activator.CreateInstance(typeof(CreateEmployeeCommand), jobs, employees) is ICommand result))
                {
                    throw new NotSupportedException($"Incorrect Employee type: {commandType}");
                }

                return result;
            }

            if (!(Activator.CreateInstance(type, jobs, employees) is ICommand currentInstance))
            {
                throw new NotSupportedException($"Incorrect Employee type: {commandType}");
            }

            return currentInstance;
        }
    }
}