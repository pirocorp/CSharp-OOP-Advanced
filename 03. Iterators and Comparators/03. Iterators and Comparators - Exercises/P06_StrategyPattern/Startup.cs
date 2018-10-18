namespace P06_StrategyPattern
{
    using System;
    using System.Collections.Generic;
    using PersonComparators;

    public class Startup
    {
        public static void Main()
        {
            var firstSortedSet = new SortedSet<Person>(new NameLengthComparator());
            var secondSortedSet = new SortedSet<Person>(new AgeComparator());

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var currentPerson = new Person(name, age);
                firstSortedSet.Add(currentPerson);
                secondSortedSet.Add(currentPerson);
            }

            PrintSet(firstSortedSet);
            PrintSet(secondSortedSet);
        }

        private static void PrintSet(SortedSet<Person> set)
        {
            foreach (var person in set)
            {
                Console.WriteLine(person);   
            }
        }
    }
}
