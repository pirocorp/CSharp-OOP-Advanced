namespace Tests
{
    using System;
    using System.Linq;
    using ExtendedDatabase;
    using NUnit.Framework;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase data;
        private int[] array;

        [SetUp]
        public void Setup()
        {
            this.data = new ExtendedDatabase();
            this.array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, })]
        [TestCase(new int[] { 1, 2, })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorWorksFine(int[] input)
        {
            this.data = new ExtendedDatabase(this.ConvertToPerson(input));

            Assert.AreEqual(input.Length, this.data.Count);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, })]
        [TestCase(new int[] { 1, 2, })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Capacity_Test_Are_Equal_To_Sixteen(int[] input)
        {
            // Arrange
            this.data = new ExtendedDatabase(this.ConvertToPerson(input));

            // Act
            var expectedCount = input.Length;
            var actualCount = this.data.Count;

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMoreThan16ElementsThrowsInvalidOperationException()
        {
            // Arrange
            this.data = new ExtendedDatabase(this.ConvertToPerson(this.array));

            // Assert
            var exception = Assert.Throws<InvalidOperationException>(() => this.data.Add(new Person(17, $"Name17")));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void DuplicateUsernamesThrowsInvalidOperationException()
        {
            this.data = new ExtendedDatabase();

            var person1 = new Person(1, "Duplicate Name");
            var person2 = new Person(2, "Duplicate Name");

            this.data.Add(person1);
            var exception = Assert.Throws<InvalidOperationException>(() => this.data.Add(person2));
            Assert.AreEqual("There is already user with this username!", exception.Message);
        }

        [Test]
        public void DuplicateIdsThrowsInvalidOperationException()
        {
            this.data = new ExtendedDatabase();

            var person1 = new Person(1, "Name");
            var person2 = new Person(1, "Another Name");

            this.data.Add(person1);
            var exception = Assert.Throws<InvalidOperationException>(() => this.data.Add(person2));

            Assert.AreEqual("There is already user with this Id!", exception.Message);
        }

        [Test]
        public void RemoveFromDatabase()
        {
            // Arrange
            this.data = new ExtendedDatabase(this.ConvertToPerson(this.array));

            for (var i = 1; i <= this.array.Length; i++)
            {
                // Act
                this.data.Remove();
                this.array = this.array.Take(this.array.Length - 1).ToArray();

                // Assert
                Assert.AreEqual(this.array.Length, this.data.Count);
            }
        }

        [Test]
        public void RemoveFromEmptyDatabaseThrowsInvalidOperationException()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => this.data.Remove());
        }

        [Test]
        public void FindByUsernameWorksFine()
        {
            var persons = this.ConvertToPerson(this.array);
            this.data = new ExtendedDatabase(persons);

            foreach (var person in persons)
            {
                var databasePerson = this.data.FindByUsername(person.UserName);

                Assert.AreEqual(person.UserName, databasePerson.UserName);
                Assert.AreEqual(person.Id, databasePerson.Id);
            }
        }

        [Test]
        public void FindByUsernameThrowsArgumentNullExceptionWithNullUsername()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => this.data.FindByUsername(null));
            Assert.IsTrue(exception.Message.Contains("Username parameter is null!"));
        }

        [Test]
        public void FindByUsernameThrowsInvalidOperationExceptionWithUsernameNotPresentInCollection()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => this.data.FindByUsername("Missing user"));
            Assert.AreEqual("No user is present by this username!", exception.Message);
        }

        [Test]
        public void FindByIdWorksFine()
        {
            var persons = this.ConvertToPerson(this.array);
            this.data = new ExtendedDatabase(persons);

            foreach (var person in persons)
            {
                var databasePerson = this.data.FindById(person.Id);

                Assert.AreEqual(person.UserName, databasePerson.UserName);
                Assert.AreEqual(person.Id, databasePerson.Id);
            }
        }

        [Test]
        public void FindByIdThrowsArgumentOutOfRangeExceptionWithNegativeId()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => this.data.FindById(-1));
            Assert.IsTrue(exception.Message.Contains("Id should be a positive number!"));
        }

        [Test]
        public void FindByIdThrowsInvalidOperationExceptionWithMissingId()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => this.data.FindById(1));
            Assert.AreEqual("No user is present by this ID!", exception.Message);
        }

        private Person[] ConvertToPerson(int[] input)
            => input
                .Select(i => new Person(i, $"Name{i}"))
                .ToArray();
    }
}