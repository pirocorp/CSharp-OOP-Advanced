namespace P04_BubbleSortTest
{
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = new[] {19, 13, 47, 49, 21, 28, 47, 35, 24, 21, 23, 29, 23, 20, 10, 48, 6};
            var bubble = new Bubble<int>(numbers);
            var result = bubble.Sort().ToArray();
        }
    }
}
