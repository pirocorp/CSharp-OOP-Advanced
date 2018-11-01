namespace P04_WorkForce.Models.Commands
{
    using System;
    using System.Collections.Generic;
    using Data;
    using Interfaces;

    public class JobCommand : Command
    {
        public JobCommand(JobList jobs, IDictionary<string, IEmployee> employees) 
            : base(jobs, employees)
        {
        }

        public JobCommand(JobList jobs, IDictionary<string, IEmployee> employees, IWriter writer, IEmployeesFactory employeesFactory) 
            : base(jobs, employees, writer, employeesFactory)
        {
        }

        public override void Execute(params string[] data)
        {
            var nameOfJob = data[1];
            var hoursOfWorkRequired = int.Parse(data[2]);
            var employeeName = data[3];
            var employee = this.employees[employeeName];

            var newJob = new Job(nameOfJob, employee, hoursOfWorkRequired);
            newJob.WorkIsDone += this.jobs.OnWorkIsDoneEvent;

            this.jobs.Add(newJob);
        }
    }
}