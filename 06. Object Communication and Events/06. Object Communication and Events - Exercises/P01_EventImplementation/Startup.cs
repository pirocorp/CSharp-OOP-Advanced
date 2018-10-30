namespace P01_EventImplementation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var dispatcher = new Dispatcher();
            var hadler = new Handler();
            dispatcher.NameChange += hadler.OnDispatcherNameChange;
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                dispatcher.Name = input;
            }
        }
    }
}
