namespace P06_TrafficLights
{
    using System;
    using System.Linq;

    public class TrafficLight
    {
        private readonly TrafficLightStates[] trafficLightsCurrentStates;

        public TrafficLight(string[] trafficLightsCurrentState)
        {
            this.trafficLightsCurrentStates = new TrafficLightStates[trafficLightsCurrentState.Length];
            this.ProcessInputStates(trafficLightsCurrentState);
        }

        private void ProcessInputStates(string[] strings)
        {
            for (var i = 0; i < strings.Length; i++)
            {
                var currentState = Enum.Parse<TrafficLightStates>(strings[i]);
                this.trafficLightsCurrentStates[i] = currentState;
            }
        }

        public void NextState()
        {
            for (var index = 0; index < this.trafficLightsCurrentStates.Length; index++)
            {
                var state = (int)this.trafficLightsCurrentStates[index] + 1;

                var maxEnum = (int)Enum.GetValues(typeof(TrafficLightStates)).Cast<TrafficLightStates>().Max() + 1;

                var newState = state % maxEnum;

                this.trafficLightsCurrentStates[index] = (TrafficLightStates) newState;
            }
        }

        public string PrintCurrentState()
        {
            return string.Join(" ", this.trafficLightsCurrentStates);
        }
    }
}