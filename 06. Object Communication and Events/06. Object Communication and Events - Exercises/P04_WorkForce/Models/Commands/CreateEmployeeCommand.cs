namespace P04_WorkForce.Models.Commands
{
    using System.Collections.Generic;
    using Interfaces;

    public class CreateEmployeeCommand : Command
    {
        public CreateEmployeeCommand(IList<IJob> jobs, IDictionary<string, IEmployee> employees) 
            : base(jobs, employees)
        {
        }

        public CreateEmployeeCommand(IList<IJob> jobs, IDictionary<string, IEmployee> employees, IWriter writer, IEmployeesFactory employeesFactory) 
            : base(jobs, employees, writer, employeesFactory)
        {
        }

        public override void Execute(params string[] data)
        {
            var name = data[1];
            IEmployee employee = this.employeesFactory.CreateEmployee(data[0], data);

            this.employees.Add(name, employee);
        }
    }
}