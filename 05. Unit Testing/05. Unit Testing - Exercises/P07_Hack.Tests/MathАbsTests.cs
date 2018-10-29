namespace P07_Hack.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class MathАbsTests
    {
        [TestCase(-3343)]
        [TestCase(-1)]
        [TestCase(1)]
        [TestCase(54642)]
        [TestCase(int.MinValue + 1)]
        [TestCase(int.MaxValue)]
        public void MathAbs_TestValues_Success(int value)
        {
            //Act
            var result = Math.Abs(value);

            //Assert
            Assert.That(result, Is.Positive);
            Assert.That(result, Is.AnyOf(value, -value));
        }

        [Test]
        public void MathAbs_TestZeroValue_Success()
        {
            //Act
            var result = Math.Abs(0);

            //Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [TestCase(-1L)]
        [TestCase(1L)]
        [TestCase(long.MinValue + 1)]
        [TestCase(long.MaxValue)]
        public void MathAbs_TestValues_Success(long value)
        {
            //Act
            var result = Math.Abs(value);

            //Assert
            Assert.That(result, Is.Positive);
            Assert.That(result, Is.AnyOf(value, -value));
        }

        [Test]
        public void MathAbs_TestLongZeroValue_Success()
        {
            //Act
            var result = Math.Abs(0L);

            //Assert
            Assert.That(result, Is.EqualTo(0L));
        }

        [TestCase((sbyte)-1)]
        [TestCase((sbyte)1)]
        [TestCase(sbyte.MinValue + 1)]
        [TestCase(sbyte.MaxValue)]
        public void MathAbs_TestValues_Success(sbyte value)
        {
            //Act
            var result = Math.Abs(value);

            //Assert
            Assert.That(result, Is.Positive);
            Assert.That(result, Is.AnyOf(value, -value));
        }

        [Test]
        public void MathAbs_TestSbyteZeroValue_Success()
        {
            //Act
            var result = Math.Abs((sbyte)0);

            //Assert
            Assert.That(result, Is.EqualTo((sbyte)0));
        }

        [TestCase((short)-1)]
        [TestCase((short)1)]
        [TestCase(short.MinValue + 1)]
        [TestCase(short.MaxValue)]
        public void MathAbs_TestValues_Success(short value)
        {
            //Act
            var result = Math.Abs(value);

            //Assert
            Assert.That(result, Is.Positive);
            Assert.That(result, Is.AnyOf(value, -value));
        }

        [Test]
        public void MathAbs_TestShortZeroValue_Success()
        {
            //Act
            var result = Math.Abs((short)0);

            //Assert
            Assert.That(result, Is.EqualTo((short)0));
        }

        [TestCase(-1.0001)]
        [TestCase(1.0001)]
        public void MathAbs_TestValue_Success(decimal value)
        {
            //Act
            var result = Math.Abs(value);

            //Assert
            Assert.That(result, Is.Positive);
            Assert.That(result, Is.AnyOf(value, -value));
        }

        [Test]
        public void MathAbs_TestDecimalZero_Success()
        {
            //Act
            var result = Math.Abs(decimal.Zero);

            //Assert
            Assert.That(result, Is.EqualTo(decimal.Zero));
        }

        [Test]
        public void MathAbs_TestDecimalOne_Success()
        {
            //Act
            var result = Math.Abs(decimal.One);

            //Assert
            Assert.That(result, Is.EqualTo(decimal.One));
        }

        [Test]
        public void MathAbs_TestDecimalNegativeOne_Success()
        {
            //Act
            var result = Math.Abs(decimal.MinusOne);

            //Assert
            Assert.That(result, Is.EqualTo(decimal.One));
        }

        [Test]
        public void MathAbs_DecimalMaxValue_Success()
        {
            //Act
            var result = Math.Abs(79228162514264337593543950335M);

            //Assert
            Assert.That(result, Is.Positive);
            Assert.That(result, Is.EqualTo(79228162514264337593543950335M));
        }

        [Test]
        public void MathAbs_DecimalMinValue_Success()
        {
            //Act
            var result = Math.Abs(-79228162514264337593543950335M);

            //Assert
            Assert.That(result, Is.Positive);
            Assert.That(result, Is.EqualTo(79228162514264337593543950335M));
        }

        [TestCase(0.1D)]
        [TestCase(2.0001D)]
        [TestCase(-0.1D)]
        [TestCase(-30.0001D)]
        [TestCase(double.MinValue)]
        [TestCase(double.MaxValue)]
        public void MathAbs_TestValues_Success(double value)
        {
            //Act
            var result = Math.Abs(value);

            //Assert
            Assert.That(result, Is.Positive);
            Assert.That(result, Is.AnyOf(value, -value));
        }

        [Test]
        public void MathAbs_TestDoubleZeroValue_Success()
        {
            //Act
            var result = Math.Abs(0D);

            //Assert
            Assert.That(result, Is.EqualTo(0D));
        }

        [TestCase(0.1F)]
        [TestCase(2.0001F)]
        [TestCase(-0.1F)]
        [TestCase(-30.0001F)]
        [TestCase(float.MinValue)]
        [TestCase(float.MaxValue)]
        public void MathAbs_TestValues_Success(float value)
        {
            //Act
            var result = Math.Abs(value);

            //Assert
            Assert.That(result, Is.Positive);
            Assert.That(result, Is.AnyOf(value, -value));
        }

        [Test]
        public void MathAbs_TestFloatZeroValue_Success()
        {
            //Act
            var result = Math.Abs(0F);

            //Assert
            Assert.That(result, Is.EqualTo(0F));
        }
    }
}
