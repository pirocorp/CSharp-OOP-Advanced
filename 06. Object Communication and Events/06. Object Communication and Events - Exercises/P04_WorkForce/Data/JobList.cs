namespace P04_WorkForce.Data
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class JobList : List<IJob>
    {
        public void JobDone(object sender, EventArgs e)
        {
            var currentJob = (IJob)sender;
            this.Remove(currentJob);

            Console.WriteLine($"Job {currentJob.Name} done!");
        }
    }
}