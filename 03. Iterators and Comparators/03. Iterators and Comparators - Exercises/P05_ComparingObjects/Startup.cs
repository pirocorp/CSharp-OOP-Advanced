namespace P05_ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var persons = new List<Person>();

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];

                persons.Add(new Person(name, age, town));
            }

            var n = int.Parse(Console.ReadLine());

            var benchmarkPerson = persons[n - 1];
            var equalsToBenchmarkPerson = 0;

            foreach (var person in persons)
            {
                if (person.CompareTo(benchmarkPerson) == 0)
                {
                    equalsToBenchmarkPerson++;
                }
            }

            if (equalsToBenchmarkPerson <= 1)
            {
                Console.WriteLine($"No matches");
                return;
            }

            Console.WriteLine($"{equalsToBenchmarkPerson} {persons.Count - equalsToBenchmarkPerson} {persons.Count}");
        }
    }
}
