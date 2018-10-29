namespace P10_TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LOW_PRESSURE_THRESHOLD = 17;
        private const double HIGH_PRESSURE_THRESHOLD = 21;

        readonly ISensor sensor = new Sensor();

        public bool AlarmOn { get; private set; }

        public void Check()
        {
            var psiPressureValue = this.sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LOW_PRESSURE_THRESHOLD || HIGH_PRESSURE_THRESHOLD < psiPressureValue)
            {
                this.AlarmOn = true;
            }
        }
    }
}
