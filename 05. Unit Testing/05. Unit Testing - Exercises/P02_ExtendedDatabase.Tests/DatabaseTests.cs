namespace P02_ExtendedDatabase.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Initialize()
        {
            this.database = new Database();
        }

        [Test]
        public void Add_AddPersonToDatabase_Success()
        {
            //Act
            for (var i = 1; i < 101; i++)
            {
                var currentPerson = new Person(i, $"{i}Asdf{i}");
                //Assert
                Assert.That(() => this.database.Add(currentPerson), Throws.Nothing);
            }
        }

        [Test]
        public void Add_AddPersonWithSameIdToDatabase_ThrowsInvalidOperationException()
        {
            //Arrange
            var person = new Person(5, "Pesho");
            var otherPerson = new Person(5, "Gosho");

            //Act
            this.database.Add(person);

            //Assert
            Assert.That(() => this.database.Add(otherPerson), Throws.InvalidOperationException
                .With.Message.EqualTo("There is already person with such id."));
        }

        [Test]
        public void Add_AddPersonWithSameUsernameToDatabase_ThrowsInvalidOperationException()
        {
            //Arrange
            var person = new Person(5, "Pesho");
            var otherPerson = new Person(53, "Pesho");

            //Act
            this.database.Add(person);

            //Assert
            Assert.That(() => this.database.Add(otherPerson), Throws.InvalidOperationException
                .With.Message.EqualTo("There is already person with such username."));
        }

        [TestCase(5, "P", 6, "p")]
        [TestCase(5, "aAa", 6, "aaa")]
        [TestCase(5, "ZZZ", 6, "zzz")]
        [TestCase(5, "ZZZ", 6, "zZZ")]
        [TestCase(5, "ZZZ", 6, "zzZ")]
        public void Add_CheckForCaseSensitive_Success(int person1Id, string person1User, int person2Id, string person2User)
        {
            //Arrange
            var person1 = new Person(person1Id, person1User);
            var person2 = new Person(person2Id, person2User);

            //Act
            this.database.Add(person1);

            //Assert
            Assert.That(() => this.database.Add(person2), Throws.Nothing);
        }

        [Test]
        public void Remove_RemovePersonFromDatabase_Success()
        {
            //Act
            for (var i = 1; i <= 10; i++)
            {
                var currentPerson = new Person(i, $"{i}Name");
                this.database.Add(currentPerson);
            }

            //Assert
            for (var i = 0; i < 10; i++)
            {
                Assert.That(() => this.database.Remove(), Throws.Nothing);
            }
        }

        [Test]
        public void Remove_FromEmptyDatabase_TrowsInvalidOperationException()
        {
            //Assert
            Assert.That(() => this.database.Remove(), Throws.InvalidOperationException
                .With.Message.EqualTo("Database is empty."));
        }

        [Test]
        public void FindByUsername_UserPresent_Success()
        {
            //Arrange
            for (var i = 1; i < 11; i++)
            {
                var person = new Person(i, $"Name{i}");
                this.database.Add(person);
            }

            //Assert
            for (var i = 1; i < 11; i++)
            {
                Assert.That(() => this.database.FindByUsername($"Name{i}"), Throws.Nothing);
            }
        }

        [Test]
        public void FindById_UserPresent_Success()
        {
            //Arrange
            for (var i = 1; i < 11; i++)
            {
                var person = new Person(i, $"Name{i}");
                this.database.Add(person);
            }

            //Assert
            for (var i = 1; i < 11; i++)
            {
                Assert.That(() => this.database.FindById(i), Throws.Nothing);
            }
        }


        [Test]
        public void FindByUsername_NotPresent_TrowsInvalidOperationException()
        {
            //Arrange
            var person = new Person(5, "Pesho");

            //Act
            this.database.Add(person);

            //Assert
            Assert.That(() => this.database.FindByUsername("Gosho"), Throws.InvalidOperationException
                .With.Message.EqualTo("No such username."));
        }

        [Test]
        public void FindByUsername_CaseSensitiveUserNotPresent_TrowsInvalidOperationException()
        {
            //Arrange
            for (var i = 1; i < 11; i++)
            {
                var person = new Person(i, $"Name{i}");
                this.database.Add(person);
            }

            //Assert
            for (var i = 1; i < 11; i++)
            {
                Assert.That(() => this.database.FindByUsername($"name{i}"), Throws.InvalidOperationException
                    .With.Message.EqualTo("No such username."));
            }
        }

        [Test]
        public void FindByUsername_ParameterIsNull_Trows_ArgumentNullException()
        {
            //Arrange
            this.database.Add(new Person(4, "a"));

            //Assert
            Assert.That(() => this.database.FindByUsername(null), Throws.ArgumentNullException
                .With.Message.EqualTo($"Cannot search for empty username.{Environment.NewLine}Parameter name: username"));
        }

        [Test]
        public void FindById_UserNotPresent_TrowsInvalidOperationException()
        {
            //Arrange
            this.database.Add(new Person(4, "a"));

            //Assert
            Assert.That(() => this.database.FindById(5), Throws.InvalidOperationException
                .With.Message.EqualTo($"No such username."));
        }

        [TestCase(-5)]
        [TestCase(-5333)]
        [TestCase(0)]
        public void FindById_NegativeOrZeroId_TrowsArgumentOutOfRangeException(long id)
        {

            //Assert
            Assert.That(() => this.database.FindById(id), Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.Contain($"cannot be negative or zero."));
        }
    }
}