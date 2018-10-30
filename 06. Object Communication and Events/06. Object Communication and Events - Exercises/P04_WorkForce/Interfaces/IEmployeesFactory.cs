namespace P04_WorkForce.Interfaces
{
    public interface IEmployeesFactory
    {
        IEmployee CreateEmployee(string employeeType, string[] data);
    }
}
