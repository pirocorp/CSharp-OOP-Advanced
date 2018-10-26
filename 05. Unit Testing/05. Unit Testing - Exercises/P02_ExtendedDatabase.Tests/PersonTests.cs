namespace P02_ExtendedDatabase.Tests
{
    using System;
    using NUnit.Framework;
    using P02_ExtendedDatabase;

    [TestFixture]
    public class PersonTests
    {

        
        [TestCase(long.MaxValue, "Gosho")]
        [TestCase(int.MaxValue, "Asen")]
        [TestCase(152, "Pesho")]
        [TestCase(1, "Pesho")]
        public void Constructor_CreatePerson_InstanceIsCreated(long personId, string username)
        {
            //Arrange
            var person = new Person(personId, username);

            //Assert
            Assert.That(person.Id, Is.EqualTo(personId));
            Assert.That(person.Username, Is.EqualTo(username));
        }

        [TestCase(654654, "")]
        [TestCase(654654, null)]
        [TestCase(long.MaxValue, "")]
        [TestCase(long.MaxValue, null)]
        public void Constructor_CreatePerson_TrowArgumentException(long personId, string username)
        {
            //Assert
            Assert.That(() => new Person(personId, username), Throws.ArgumentException
                .With.Message.Contain("cannot be empty."));
        }

        [TestCase(long.MinValue, "Pesho")]
        [TestCase(int.MinValue, "Pesho")]
        [TestCase(-1, "Pesho")]
        [TestCase(0, "Pesho")]
        public void Constructor_CreatePerson_TrowArgumentOutOfRangeException(long personId, string username)
        {
            //Assert
            Assert.That(() => new Person(personId, username), Throws.InstanceOf<ArgumentOutOfRangeException>()
                .With.Message.Contain("cannot be negative or zero."));
        }

        [TestCase(long.MaxValue, "Gosho")]
        [TestCase(int.MaxValue, "A")]
        [TestCase(152, "Pesho")]
        [TestCase(1, "Pesho")]
        [TestCase(1, "A")]
        public void ToString_StringOutput_MustBeEqual(long personId, string username)
        {
            //Arrange
            var person = new Person(personId, username);

            //Assert
            Assert.That(person.ToString(), Is.EqualTo($"{personId} - {username}"));
        }
    }
}