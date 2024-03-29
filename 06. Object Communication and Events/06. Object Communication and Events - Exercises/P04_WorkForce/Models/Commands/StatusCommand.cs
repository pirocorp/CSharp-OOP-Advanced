﻿namespace P04_WorkForce.Models.Commands
{
    using System.Collections.Generic;
    using Data;
    using Interfaces;

    public class StatusCommand : Command
    {
        public StatusCommand(JobList jobs, IDictionary<string, IEmployee> employees) 
            : base(jobs, employees)
        {
        }

        public StatusCommand(JobList jobs, IDictionary<string, IEmployee> employees, IWriter writer, IEmployeesFactory employeesFactory) 
            : base(jobs, employees, writer, employeesFactory)
        {
        }

        public override void Execute(params string[] data)
        {
            foreach (var job in this.jobs)
            {
                this.writer.WriteLine(job);
            }
        }
    }
}