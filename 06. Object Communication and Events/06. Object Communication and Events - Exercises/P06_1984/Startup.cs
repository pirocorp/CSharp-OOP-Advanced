namespace P06_1984
{
    using System;
    using Core;
    using Entities;
    using Entities.EventArgs;

    public class Startup
    {
        public static void Main()
        {
            //var employee = new Employee(1, "Pesho", 5000);
            //var company = new Company(3, "Pirosoft", 10000, 5000);
            //var mvr = new Institution(2, "MVr");
            //mvr.RegisterInterest("name", employee);
            //mvr.RegisterInterest("turnover", company);
            //employee.Name = "Gosho";
            //company.Turnover = 50000;
            //Console.WriteLine(mvr.ReportChanges());

            var engine = new Engine();
            engine.Run();
        }
    }
}
