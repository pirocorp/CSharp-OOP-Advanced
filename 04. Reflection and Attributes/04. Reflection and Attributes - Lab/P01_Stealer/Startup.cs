namespace P01_Stealer
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var spy = new Spy();
            var result = spy.CollectGettersAndSetters(nameof(Hacker));
            Console.WriteLine(result);
        }
    }
}
