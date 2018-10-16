namespace P01_GenericBoxOfString
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var boxes = new Box<string>[n];

            for (var i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();
                var currentBox = new Box<string>(inputLine);
                boxes[i] = currentBox;
            }

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}