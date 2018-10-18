namespace P07_EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                var currentPerson = new Person(name, age);

                sortedSet.Add(currentPerson);
                hashSet.Add(currentPerson);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
