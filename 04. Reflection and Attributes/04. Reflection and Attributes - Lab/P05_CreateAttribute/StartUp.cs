namespace P05_CreateAttribute
{
    using Attributes;

    [SoftUni("Zdravko")]
    class StartUp
    {
        [SoftUni("Zdravko")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
