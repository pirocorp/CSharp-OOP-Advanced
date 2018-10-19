namespace P09_LinkedListTraversal
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var linkedList = new MyGenericLinkedList<int>();

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var number = int.Parse(tokens[1]);

                if (command == "Add")
                {
                    linkedList.Add(number);
                }
                else if (command == "Remove")
                {
                    linkedList.Remove(number);
                }
            }

            Console.WriteLine(linkedList.Count);

            foreach (var item in linkedList)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }
    }
}
