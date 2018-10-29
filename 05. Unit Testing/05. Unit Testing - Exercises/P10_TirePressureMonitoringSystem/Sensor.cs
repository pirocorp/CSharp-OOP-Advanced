namespace P10_TirePressureMonitoringSystem
{
    using System;

    public class Sensor : ISensor
    {
        //
        // The reading of the pressure value from the sensor is simulated in this implementation.
        // Because the focus of the exercise is on the other class.
        //

        const double OFFSET = 16;
        readonly Random randomPressureSampleSimulator = new Random();

        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue = this.ReadPressureSample();

            return OFFSET + pressureTelemetryValue;
        }

        private double ReadPressureSample()
        {
            // Simulate info read from a real sensor in a real tire
            return 6 * this.randomPressureSampleSimulator.NextDouble() * this.randomPressureSampleSimulator.NextDouble();
        }
    }
}
