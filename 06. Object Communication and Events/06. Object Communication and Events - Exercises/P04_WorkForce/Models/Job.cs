namespace P04_WorkForce.Models
{
    using System;
    using Interfaces;

    public delegate void EventHandler(object sender, EventArgs e);

    public class Job : IJob
    {
        private readonly IEmployee employee;
        private int hoursOfWorkRequired;

        public event EventHandler WorkIsDone;

        public Job(string name, IEmployee employee, int hoursOfWorkRequired)
        {
            this.Name = name;
            this.employee = employee;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
        }

        public string Name { get; private set; }

        private int HoursOfWorkRequired
        {
            get => this.hoursOfWorkRequired;
            set
            {
                this.hoursOfWorkRequired = value;

                if (this.hoursOfWorkRequired <= 0)
                {
                    this.WorkIsDone?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public void Update()
        {
            this.HoursOfWorkRequired -= this.employee.WorkHoursPerWeek;
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
        }
    }
}