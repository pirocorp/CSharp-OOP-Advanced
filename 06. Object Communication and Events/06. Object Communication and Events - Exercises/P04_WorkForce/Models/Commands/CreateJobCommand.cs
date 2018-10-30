namespace P04_WorkForce.Models.Commands
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class JobCommand : Command
    {
        public JobCommand(IList<IJob> jobs, IDictionary<string, IEmployee> employees) 
            : base(jobs, employees)
        {
        }

        public JobCommand(IList<IJob> jobs, IDictionary<string, IEmployee> employees, IWriter writer, IEmployeesFactory employeesFactory) 
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
            newJob.WorkIsDone += this.JobDone;

            this.jobs.Add(newJob);
        }

        private void JobDone(object sender, EventArgs e)
        {
            var currentJob = (IJob)sender;
            this.jobs.Remove(currentJob);

            Console.WriteLine($"Job {currentJob.Name} done!");
        }
    }
}