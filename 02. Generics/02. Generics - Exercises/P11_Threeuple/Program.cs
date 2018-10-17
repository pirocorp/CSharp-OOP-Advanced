namespace P11_Threeuple
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var name = $"{tokens[0]} {tokens[1]}";
            var address = tokens[2];
            var town = tokens[3];

            var tuple1 = new Threeuple<string, string, string>(name, address, town);

            tokens = Console.ReadLine().Split();
            name = tokens[0];
            var litersOBeer = int.Parse(tokens[1]);

            var condition = tokens[2].ToLower() == "drunk";

            var tuple2 = new Threeuple<string, int, bool>(name, litersOBeer, condition);

            tokens = Console.ReadLine().Split();
            name = tokens[0];
            var accountBalance = double.Parse(tokens[1]);
            var bankName = tokens[2];

            var tuple3 = new Threeuple<string, double, string>(name, accountBalance, bankName);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
