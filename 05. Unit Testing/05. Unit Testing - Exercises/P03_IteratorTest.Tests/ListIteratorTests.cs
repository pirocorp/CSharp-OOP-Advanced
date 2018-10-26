namespace P03_IteratorTest.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ListIteratorTests
    {
        [Test]
        public void Constructor_NullPassedToConstructor_TrowArgumentNullException()
        {
            //Assert
            Assert.That(() => new ListIterator(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Move_MoveToNextIndex_ReturnTrue()
        {
            //Arrange
            var list = new ListIterator(new []{"", "", "", "", "", "" });

            //Assert
            for (var i = 0; i < 5; i++)
            {
                Assert.That(() => list.Move(), Is.True);
            }
        }

        [Test]
        public void Move_MoveToNextIndex_ReturnFalse()
        {
            //Arrange
            var list = new ListIterator(new[] { "", "", "", "", "", "" });

            //Act
            for (var i = 0; i < 5; i++)
            {
                list.Move();
            }

            //Assert
            Assert.That(() => list.Move(), Is.False);
        }

        [Test]
        public void HasNextIndex_CheckForNextIndex_ReturnTrue()
        {
            //Arrange
            var list = new ListIterator(new[] { "", ""});

            //Assert
            Assert.That(() => list.HasNext(), Is.True);
        }

        [Test]
        public void HasNextIndex_CheckForNextIndex_ReturnFalse()
        {
            //Arrange
            var list = new ListIterator(new[] { "", "" });

            //Act
            list.Move();

            //Assert
            Assert.That(() => list.HasNext(), Is.False);
        }

        [Test]
        [MaxTime(100)]
        public void Print_ElementsArePresentInList_PrintElement()
        {
            //Arrange
            var list = new ListIterator(new[] { "First", "Second", "Third", "Forth", "Fifth", "Sixth", "Seventh", "Eight", });

            //Assert
            while (list.HasNext())
            {
                Assert.That(() => list.Print(), Is.TypeOf<string>());
                list.Move();
            }
        }

        [Test]
        public void Print_CollectionWithoutElements_TrowsInvalidOperationException()
        {
            //Arrange
            var list = new ListIterator(new string[] { });

            //Assert
            Assert.That(() => list.Print(), Throws.InvalidOperationException
                .With.Message.EqualTo("Invalid Operation!"));
        }

    }
}