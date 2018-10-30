namespace P04_WorkForce.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;
    using Models.Employees;

    public class Engine
    {
        private readonly IDictionary<string, IEmployee> employees;
        private readonly IList<IJob> jobs;

        public Engine()
        {
            this.employees = new Dictionary<string, IEmployee>();
            this.jobs = new List<IJob>();
        }

        public void Run()
        {
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "End")
            {
                var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                switch (command)
                {
                    case "Job":
                        this.CreateJob(tokens);
                        break;
                    case "StandardEmployee":
                        this.CreateEmployee("Standard", tokens);
                        break;
                    case "PartTimeEmployee":
                        this.CreateEmployee("PartTime", tokens);
                        break;
                    case "Pass":
                        this.PassWeek();
                        break;
                    case "Status":
                        this.Status();
                        break;
                }
            }
        }

        private void Status()
        {
            foreach (var job in this.jobs)
            {
                Console.WriteLine(job);
            }
        }

        private void PassWeek()
        {
            //Make copy of List into array because if some job become done it will
            //disappear from list and this will lead to skipping call to next job update method
            var newListOfJobs = this.jobs.ToArray();

            foreach (var job in newListOfJobs)
            {
                job.Update();
            }
        }

        private void CreateJob(string[] tokens)
        {
            var nameOfJob = tokens[1];
            var hoursOfWorkRequired = int.Parse(tokens[2]);
            var employeeName = tokens[3];
            var employee = this.employees[employeeName];

            var newJob = new Job(nameOfJob, employee, hoursOfWorkRequired);
            newJob.WorkIsDone += this.JobDone;

            this.jobs.Add(newJob);
        }

        private void JobDone(object sender, EventArgs e)
        {
            var currentJob = (IJob) sender;
            this.jobs.Remove(currentJob);

            Console.WriteLine($"Job {currentJob.Name} done!");
        }

        private void CreateEmployee(string type, string[] data)
        {
            var name = data[1];
            IEmployee employee = null;

            switch (type)
            {
                case "Standard":
                    employee = new StandardEmployee(name);
                    break;
                case "PartTime":
                    employee = new PartTimeEmployee(name);
                    break;
            }

            this.employees.Add(name, employee);
        }
    }
}