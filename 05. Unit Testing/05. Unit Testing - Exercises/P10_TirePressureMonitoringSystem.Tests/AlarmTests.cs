namespace P10_TirePressureMonitoringSystem.Tests
{
    using System.Reflection;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class AlarmTests
    {
        [Test]
        public void AlarmOn_DefaultValueIsFalse_True()
        {
            //Arrange
            var alarm = new Alarm();

            //Assert
            Assert.That(alarm.AlarmOn, Is.False);
        }

        [TestCase(17.001)]
        [TestCase(18.5)]
        [TestCase(20.5)]
        [TestCase(20.999)]
        [TestCase(17)]
        [TestCase(21)]
        public void Check_PressureInRange_AlarmIsFalse(double valueOfPressure)
        {
            //Arrange
            var alarm = new Alarm();
            var sensor = new Mock<ISensor>();
            sensor.Setup(s => s.PopNextPressurePsiValue()).Returns(valueOfPressure);
            var sensorFieldOfAlarm = typeof(Alarm)
                .GetField("sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            sensorFieldOfAlarm.SetValue(alarm, sensor.Object);

            //Act
            alarm.Check();

            //Assert
            Assert.That(alarm.AlarmOn, Is.False);
        }

        [TestCase(16.999)]
        [TestCase(10.3)]
        [TestCase(22.5)]
        [TestCase(21.001)]
        public void Check_PressureOutOfRange_AlarmIsFalse(double valueOfPressure)
        {
            //Arrange
            var alarm = new Alarm();
            var sensor = new Mock<ISensor>();
            sensor.Setup(s => s.PopNextPressurePsiValue()).Returns(valueOfPressure);
            var sensorFieldOfAlarm = typeof(Alarm)
                .GetField("sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            sensorFieldOfAlarm.SetValue(alarm, sensor.Object);

            //Act
            alarm.Check();

            //Assert
            Assert.That(alarm.AlarmOn, Is.True);
        }
    }
}