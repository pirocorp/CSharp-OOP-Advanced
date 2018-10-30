namespace P04_WorkForce.Models.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class PassWeekCommand : Command
    {
        public PassWeekCommand(IList<IJob> jobs, IDictionary<string, IEmployee> employees) 
            : base(jobs, employees)
        {
        }

        public PassWeekCommand(IList<IJob> jobs, IDictionary<string, IEmployee> employees, IWriter writer, IEmployeesFactory employeesFactory) 
            : base(jobs, employees, writer, employeesFactory)
        {
        }

        public override void Execute(params string[] data)
        {
            //Make copy of List into array because if some job become done it will
            //disappear from list and this will lead to skipping call to next job update method
            var newListOfJobs = this.jobs.ToArray();

            foreach (var job in newListOfJobs)
            {
                job.Update();
            }
        }
    }
}