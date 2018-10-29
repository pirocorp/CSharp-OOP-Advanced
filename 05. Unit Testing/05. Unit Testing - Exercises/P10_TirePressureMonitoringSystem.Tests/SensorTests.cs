namespace P10_TirePressureMonitoringSystem.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class SensorTests
    {
        [Test]
        public void PopNextPressurePsiValue_ReadPressure_Successful()
        {
            //Arrange
            var sensor = new Sensor();

            //Act
            var result = sensor.PopNextPressurePsiValue();

            //Assert
            Assert.That(result, Is.AssignableTo(typeof(double)));
        }
    }
}
