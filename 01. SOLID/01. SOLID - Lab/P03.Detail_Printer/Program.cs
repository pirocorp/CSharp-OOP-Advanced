namespace P03.Detail_Printer
{
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var consolePrinter = new ConsolePrinter();
            var documents = new[] {"Top Secret", "Not Secret"};
            var employees = new Employee[]{new Employee("Asen"), new Manager("Pesho", documents), };
            var detailsPrinter = new DetailsPrinter(employees, consolePrinter);
            detailsPrinter.PrintDetails();
        }
    }
}
