namespace P04.Recharge
{
    public class Program
    {
        public static void Main()
        {
            var employee = new Employee("worker");
            var robot = new Robot("01", 500);
            ISleeper sleeper = employee;
            IRechargeable rechargeable = robot;

        }
    }
}
