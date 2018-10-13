namespace P03.Detail_Printer
{
    using System;
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        private IList<Employee> employees;
        private readonly IPrint targetPrinter;

        public DetailsPrinter(IList<Employee> employees, IPrint targetPrinter)
        {
            this.employees = employees;
            this.targetPrinter = targetPrinter;
        }

        public void PrintDetails()
        {
            foreach (var employee in this.employees)
            {
                this.targetPrinter.Print(employee.ToString());
            }
        }
    }
}
