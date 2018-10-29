namespace P09_DateTimeNowAddDaysTests
{
    using System;
    using System.Globalization;
    using NUnit.Framework;

    [TestFixture]
    public class DateTimeNowAddDaysTests
    {
        [Test]
        public void DateTimeAddDays_AddingDayToMiddleOfTheMonth_Successful()
        {
            //Arrange
            var dateFormat = "dd/MM/yyyy";
            var date = DateTime.Parse("16/06/2009");

            //Act
            var result = date.AddDays(1).ToString(dateFormat, CultureInfo.InvariantCulture);

            //Assert
            Assert.That(result == "17/06/2009");
        }

        [Test]
        public void DateTimeAddDays_AddingDayToEndOfTheMonth_Successful()
        {
            //Arrange
            var dateFormat = "dd/MM/yyyy";
            var date = DateTime.Parse("31/07/2009");

            //Act
            var result = date.AddDays(1).ToString(dateFormat, CultureInfo.InvariantCulture);

            //Assert
            Assert.That(result == "01/08/2009");
        }

        [Test]
        public void DateTimeAddDays_NegativeValue_Successful()
        {
            //Arrange
            var dateFormat = "dd/MM/yyyy";
            var date = DateTime.Parse("31/07/2009");

            //Act
            var result = date.AddDays(-5).ToString(dateFormat, CultureInfo.InvariantCulture);

            //Assert
            Assert.That(result == "26/07/2009");
        }

        [Test]
        public void DateTimeAddDays_NegativeValueGoingPreviousMonth_Successful()
        {
            //Arrange
            var dateFormat = "dd/MM/yyyy";
            var date = DateTime.Parse("3/07/2009");

            //Act
            var result = date.AddDays(-5).ToString(dateFormat, CultureInfo.InvariantCulture);

            //Assert
            Assert.That(result == "28/06/2009");
        }

        [Test]
        public void DateTimeAddDays_AddingDayToLeapYear_Successful()
        {
            //Arrange
            var dateFormat = "dd/MM/yyyy";
            var date = DateTime.Parse("28/02/2008");

            //Act
            var result = date.AddDays(1).ToString(dateFormat, CultureInfo.InvariantCulture);

            //Assert
            Assert.That(result == "29/02/2008");
        }

        [Test]
        public void DateTimeAddDays_AddingDayToNonLeapYear_Successful()
        {
            //Arrange
            var dateFormat = "dd/MM/yyyy";
            var date = DateTime.Parse("28/02/1900");

            //Act
            var result = date.AddDays(1).ToString(dateFormat, CultureInfo.InvariantCulture);

            //Assert
            Assert.That(result == "01/03/1900");
        }

        [Test]
        public void DateTimeAddDays_DateTimeMinValue_Successful()
        {
            //Arrange
            var dateFormat = "dd/MM/yyyy";
            var date = DateTime.MinValue;

            //Act
            var result = date.AddDays(1).ToString(dateFormat, CultureInfo.InvariantCulture);

            //Assert
            Assert.That(result == "02/01/0001");
        }

        [Test]
        public void DateTimeAddDays_DateTimeMaxValue_Successful()
        {
            //Arrange
            var dateFormat = "dd/MM/yyyy";
            var date = DateTime.MaxValue;

            //Assert
            Assert.That(() => date.AddDays(1).ToString(dateFormat), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void DateTimeAddDays_SubstractDayFromDateTimeMinValue_Successful()
        {
            //Arrange
            var dateFormat = "dd/MM/yyyy";
            var date = DateTime.MinValue;

            //Assert
            Assert.That(() => date.AddDays(-1).ToString(dateFormat), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void DateTimeAddDays_SubstractDayDateTimeMaxValue_Successful()
        {
            //Arrange
            var dateFormat = "dd/MM/yyyy";
            var date = DateTime.MaxValue;

            //Act
            var result = date.AddDays(-1).ToString(dateFormat, CultureInfo.InvariantCulture);

            //Assert
            Assert.That(result == "30/12/9999");
        }
    }
}
