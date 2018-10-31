namespace P04_WorkForce.Models.Commands
{
    using System.Collections.Generic;
    using Core.Factories;
    using Data;
    using Interfaces;
    using IO;

    public abstract class Command : ICommand
    {
        protected readonly JobList jobs;
        protected readonly IDictionary<string, IEmployee> employees;
        protected readonly IWriter writer;
        protected readonly IEmployeesFactory employeesFactory;

        protected Command(JobList jobs, IDictionary<string, IEmployee> employees)
            :this(jobs, employees, new ConsoleWriter(), new EmployeesFactory())
        {
            
        }

        protected Command(JobList jobs, IDictionary<string, IEmployee> employees, IWriter writer, IEmployeesFactory employeesFactory)
        {
            this.jobs = jobs;
            this.employees = employees;
            this.writer = writer;
            this.employeesFactory = employeesFactory;
        }

        public abstract void Execute(params string[] data);
    }
}