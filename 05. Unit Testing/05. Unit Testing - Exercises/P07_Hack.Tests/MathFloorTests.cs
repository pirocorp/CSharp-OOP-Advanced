namespace P07_Hack.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class MathFloorTests
    {
        [TestCase(3.4)]
        [TestCase(-3.4)]
        [TestCase(0.111)]
        [TestCase(-0.111)]
        [TestCase(910.999)]
        [TestCase(-100.35)]
        public void MathFloor_DoubleTestValues_Success(double value)
        {
            //Act
            var result = Math.Floor(value);

            //Assert
            Assert.That(result < value);
        }

        [TestCase(5.4)]
        [TestCase(-2.4)]
        [TestCase(0.3369)]
        [TestCase(-0.56565)]
        [TestCase(36363.949)]
        [TestCase(-1005.32)]
        public void MathFloor_DoubleTestValues_Success(decimal value)
        {
            //Act
            var result = Math.Floor(value);

            //Assert
            Assert.That(result < value);
        }
    }
}