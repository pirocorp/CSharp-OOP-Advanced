namespace P06_TrafficLights
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var inputStatesOrder = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
            var trafficLight = new TrafficLight(inputStatesOrder);
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                trafficLight.NextState();
                Console.WriteLine(trafficLight.PrintCurrentState());
            }
        }
    }
}
