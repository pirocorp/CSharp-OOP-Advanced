namespace P01_Database.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void Constructor_NoParameters_FetchZeroElements()
        {
            //Arrange
            var zeroElements = 0;
            var database = new Database();

            //Act
            var elements = database.Fetch.Count;

            //Assert
            Assert.That(elements, Is.EqualTo(zeroElements));
        }

        [TestCase(new int[0])]
        [TestCase(new[] { 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Constructor_Parameters_FetchSameNumberParameters(int[] parameters)
        {
            //Arrange
            var database = new Database(parameters);

            //Act
            var elements = database.Fetch.Count;

            //Assert
            Assert.That(elements, Is.EqualTo(parameters.Length));
        }

        [Test]
        public void Constructor_TooManyInputParameters_TrowException()
        {
            //Assert
            Assert.That(() => new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17), 
                Throws.InstanceOf<InvalidOperationException>().With.Message.EqualTo("Array is full."));
        }

        [TestCase(new int[0])]
        [TestCase(new[] { 1 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Fetch_Parameters_ReturnSameParameters(int[] parameters)
        {
            //Arrange
            var database = new Database(parameters);

            //Act
            var inputParameters = string.Join(", ", parameters);
            var databaseParameters = string.Join(", ", database.Fetch);

            //Assert
            Assert.That(inputParameters, Is.EqualTo(databaseParameters));
        }

        [TestCase(new int[0])]
        [TestCase(new[] {1})]
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15})]
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void Add_Parameters_FetchSameNumberParameters(int[] parameters)
        {
            //Arrange
            var database = new Database();

            //Act
            foreach (var parameter in parameters)
            {
                database.Add(parameter);
            }

            //Assert
            Assert.That(database.Fetch.Count, Is.EqualTo(parameters.Length));
        }

        [Test]
        public void Add_TooManyParametersToAdd_TrowException()
        {
            //Arrange
            var parametersToAddCount = 16;
            var database = new Database();

            //Act
            for (var i = 0; i < parametersToAddCount; i++)
            {
                database.Add(i);
            }

            //Assert
            Assert.That(() => database.Add(parametersToAddCount + 1), 
                Throws.Exception.With.Message.EqualTo("Array is full."));
        }

        [TestCase(new int[0])]
        [TestCase(new[] {1})]
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15})]
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void Remove_Parameters_SuccessfulRemovedParameters(int[] parameters)
        {
            //Arrange
            var zeroElements = 0;
            var database = new Database(parameters);

            //Act
            for (var i = 0; i < parameters.Length; i++)
            {
                database.Remove();
            }

            //Assert
            Assert.That(database.Fetch.Count, Is.EqualTo(zeroElements));
        }

        [Test]
        public void Remove_RemoveFromEmptyDatabase_ThrowsException()
        {
            //Arrange
            var database = new Database();

            //Assert
            Assert.That(() => database.Remove(), Throws.InstanceOf<InvalidOperationException>()
                .With.Message.EqualTo("Array is empty."));
        }
    }
}
