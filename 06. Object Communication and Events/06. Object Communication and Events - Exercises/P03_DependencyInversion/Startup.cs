namespace P03_DependencyInversion
{
    using System;
    using Factories;

    public class Startup
    {
        public static void Main()
        {
            var calc = new PrimitiveCalculator();

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "End")
            {
                var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                var firstArgument = tokens[0].ToLower();
                var secondArgument = tokens[1];

                if (firstArgument == "mode")
                {
                    calc.ChangeStrategy(secondArgument[0]);
                    continue;
                }

                var a = int.Parse(firstArgument);
                var b = int.Parse(secondArgument);

                var result = calc.PerformCalculation(a, b);

                Console.WriteLine(result);
            }
        }
    }
}
