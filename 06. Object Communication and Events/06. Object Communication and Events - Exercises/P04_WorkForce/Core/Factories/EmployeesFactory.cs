namespace P04_WorkForce.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Interfaces;

    public class EmployeesFactory : IEmployeesFactory
    {
        public IEmployee CreateEmployee(string employeeType, string[] data)
        {
            var name = data[1];

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == $"{employeeType}");

            if (type == null)
            {
                throw new NotSupportedException($"Not supported Employee type: {employeeType}");
            }

            if (!(Activator.CreateInstance(type, name) is IEmployee currentInstance))
            {
                throw new NotSupportedException($"Incorrect Employee type: {employeeType}");
            }

            return currentInstance;
        }
    }
}