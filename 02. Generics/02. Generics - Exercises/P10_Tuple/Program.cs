namespace P10_Tuple
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var name = $"{tokens[0]} {tokens[1]}";
            var address = tokens[2];

            var tuple1 = new Tuple<string, string>(name, address);

            tokens = Console.ReadLine().Split();
            name = tokens[0];
            var litersOBeer = int.Parse(tokens[1]);

            var tuple2 = new Tuple<string, int>(name, litersOBeer);

            tokens = Console.ReadLine().Split();
            var integer = int.Parse(tokens[0]);
            var doubleParameter = double.Parse(tokens[1]);

            var tuple3 = new Tuple<int, double>(integer, doubleParameter);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
