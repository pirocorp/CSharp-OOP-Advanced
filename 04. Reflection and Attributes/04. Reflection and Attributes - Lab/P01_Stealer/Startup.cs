namespace P01_Stealer
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var spy = new Spy();
            var result = spy.RevealPrivateMethods(nameof(Hacker));
            Console.WriteLine(result);
        }
    }
}
