namespace P04_WorkForce.Models.Employees
{
    public class StandardEmployee : Employee
    {
        private const int WORKING_HOURS = 40;

        public StandardEmployee(string name) 
            : base(name, WORKING_HOURS)
        {
        }
    }
}