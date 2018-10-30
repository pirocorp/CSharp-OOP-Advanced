namespace P04_WorkForce.Models.Employees
{
    public class PartTimeEmployee : Employee
    {
        private const int WORKING_HOURS = 20;

        public PartTimeEmployee(string name) 
            : base(name, WORKING_HOURS)
        {
        }
    }
}