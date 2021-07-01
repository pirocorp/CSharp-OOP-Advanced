namespace Tests
{
    using System;
    using System.Linq;
    using System.Reflection;

    //using CarManager;

    using NUnit.Framework;

    public class CarTests
    {
        [TestCase("BMW", "Series 8", 10.5, 85)]
        [TestCase("Opel", "Astra", 8, 65)]
        [TestCase("   ", "    ", 10.5, 85)]
        public void CarConstructorWorksFine(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            var car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(0, car.FuelAmount);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [TestCase("", "Series 8", 10.5, 85)]
        [TestCase(null, "Astra", 8, 65)]
        public void CarConstructorThrowsArgumentExceptionWithNullOrEmptyMake(string make, string model,
            double fuelConsumption, double fuelCapacity)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [TestCase("BMW", "", 10.5, 85)]
        [TestCase("Opel", null, 8, 65)]
        public void CarConstructorThrowsArgumentExceptionWithNullOrEmptyModel(string make, string model,
            double fuelConsumption, double fuelCapacity)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [TestCase("BMW", "Series 8", 0, 85)]
        [TestCase("Opel", "Astra", -8, 65)]
        public void CarConstructorThrowsArgumentExceptionWithZeroOrNegativeFuelConsumption(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [TestCase("BMW", "Series 8", 10.5, 0)]
        [TestCase("Opel", "Astra", 8, -65)]
        public void CarConstructorThrowsArgumentExceptionWithZeroOrNegativeFuelCapacity(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [TestCase(20)]
        [TestCase(40)]
        [TestCase(int.MaxValue)]
        public void RefuelWorksFine(int amount)
        {
            var car = new Car("   ", "   ", 10, 65);
            var expectedAmount = Math.Min(amount, car.FuelCapacity);

            car.Refuel(amount);

            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }

        [TestCase(10, 20, 30)]
        [TestCase(15, 20, 30)]
        [TestCase(15, 40, 5000)]
        public void MultipleRefuelsWorksFine(params int[] amounts)
        {
            var car = new Car("   ", "   ", 10, 65);
            var expectedAmount = Math.Min(amounts.Sum(), car.FuelCapacity);

            foreach (var amount in amounts)
            {
                car.Refuel(amount);
            }

            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }

        [TestCase(0)]
        [TestCase(-30)]
        public void RefuelThrowsArgumentExceptionWithZeroOrNegativeAmount(int amount)
        {
            var car = new Car("   ", "   ", 10, 65);

            var exception = Assert.Throws<ArgumentException>(() => car.Refuel(amount));
            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [TestCase(10)]
        [TestCase(50)]
        [TestCase(100)]
        public void DriveWorksFine(double distance)
        {
            var car = new Car("   ", "   ", 10, 100);

            car.Refuel(10);
            car.Drive(distance);
        }

        [Test]
        public void TestDrivingCorrectly()
        {
            var car = new Car("Audi", "A4", 15, 300);

            car.Refuel(10);
            car.Drive(10);
            var expectedFuel = 8.5;

            Assert.AreEqual(expectedFuel, car.FuelAmount);
        }

        [TestCase(100.001)]
        [TestCase(200)]
        [TestCase(300)]
        public void DriveThrowsWhenNotEnoughFuel(double distance)
        {
            var car = new Car("   ", "   ", 10, 100);

            car.Refuel(10);
            var exception = Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }

        [TestCase(50)]
        [TestCase(0)]
        public void FuelAmountSetterWorksFine(double value)
        {
            var car = new Car("   ", "   ", 10, 100);
            var fuelAmountProperty = typeof(Car).GetProperty(nameof(Car.FuelAmount));

            fuelAmountProperty.SetValue(car, value);

            Assert.AreEqual(value, car.FuelAmount);
        }

        [TestCase(-50)]
        public void FuelAmountSetterThrowsWithNegative(double value)
        {
            var car = new Car("   ", "   ", 10, 100);
            var fuelAmountProperty = typeof(Car).GetProperty(nameof(Car.FuelAmount));

            var exception = Assert.Throws<TargetInvocationException>(() => fuelAmountProperty.SetValue(car, value));

            Assert.AreEqual(typeof(ArgumentException), exception.InnerException.GetType());
            Assert.AreEqual("Fuel amount cannot be negative!", exception.InnerException.Message);
        }
    }
}
