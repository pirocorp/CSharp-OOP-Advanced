namespace Tests
{
    using System;
    using System.Linq;

    using Database;

    using NUnit.Framework;

    public class DatabaseTests
    {
        private Database data;
        private int[] array;

        [SetUp]
        public void Setup()
        {
            this.data = new Database();
            this.array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, })]
        [TestCase(new int[] { 1, 2, })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Capacity_Test_Are_Equal_To_Sixteen(int[] array)
        {
            // Arrange
            this.data = new Database(array);

            // Act
            var expectedCount = array.Length;
            var actualCount = this.data.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMoreThan16ElementsThrowsInvalidOperationException()
        {
            // Arrange
            this.data = new Database(this.array);

            // Assert
            var exception = Assert.Throws<InvalidOperationException>(() => this.data.Add(17));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void RemoveFromDatabase()
        {
            // Arrange
            this.data = new Database(this.array);

            for (var i = 1; i <= this.array.Length; i++)
            {
                // Act
                this.data.Remove();
                this.array = this.array.Take(this.array.Length - 1).ToArray();

                // Assert
                Assert.AreEqual(this.array.Length, this.data.Count);

                var databaseElements = this.data.Fetch();
                for (var j = 0; j < this.array.Length; j++)
                {
                    Assert.AreEqual(this.array[j], databaseElements[j]);
                }
            }
        }

        [Test]
        public void RemoveFromEmptyDatabaseThrowsInvalidOperationException()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => this.data.Remove());
            Assert.AreEqual("The collection is empty!", exception.Message);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, })]
        [TestCase(new int[] { 1, 2, })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchWorksProperly(int[] input)
        {
            // Arrange
            this.data = new Database(input);

            // Act
            var databaseElements = this.data.Fetch();

            // Assert
            Assert.AreEqual(input.Length, databaseElements.Length);
            for (var j = 0; j < input.Length; j++)
            {
                Assert.AreEqual(input[j], databaseElements[j]);
            }
        }
    }
}
