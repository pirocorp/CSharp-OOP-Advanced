namespace P08_CustomLinkedList.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class DynamicListTests
    {
        [Test]
        public void Constructor_CreateInstance_Successful()
        {
            //Assert
            Assert.That(() => new DynamicList<int>(), Throws.Nothing);
        }

        [Test]
        public void Add_AddElements_ElementsAreSameNumber()
        {
            //Arrange
            var numberOfGeneratedStrings = 10;
            var elements = new List<string>();

            for (var i = 0; i < numberOfGeneratedStrings; i++)
            {
                var currentString = $"Generated String {i}";
                elements.Add(currentString);
            }

            var dynamicList = new DynamicList<string>();

            //Act
            for (var i = 0; i < elements.Count; i++)
            {
                dynamicList.Add(elements[i]);
                Assert.That(dynamicList[i], Is.SameAs(elements[i]));
            }

            //Assert
            Assert.That(dynamicList.Count, Is.EqualTo(numberOfGeneratedStrings));
        }

        [Test]
        public void Add_AddNull_ThrowsNothing()
        {
            //Arrange
            var list = new DynamicList<string>();

            //Assert
            Assert.That(() => list.Add(null), Throws.Nothing);
        }

        [Test]
        public void Add_SeveralNulls_ThrowsNothing()
        {
            //Arrange
            var list = new DynamicList<string>();
            list.Add(null);
            list.Add(null);
            list.Add(null);
            list.Add(null);

            //Assert
            Assert.That(() => list.Add(null), Throws.Nothing);
        }

        [Test]
        public void Count_CountEmptyList_ElementsAreZero()
        {
            //Arrange
            var list = new DynamicList<string>();

            //Act
            var result = list.Count;

            Assert.That(result == 0);
        }

        [Test]
        public void Indexer_IterateTroughElements_Successful()
        {
            //Arrange
            var numberOfElements = 10;
            var list = new DynamicList<string>();
            var elements = new List<string>();

            //Act
            for (var i = 0; i < numberOfElements; i++)
            {
                var currentElement = $"String{i}";
                list.Add(currentElement);
                elements.Add(currentElement);
            }

            //Assert
            for (var i = 0; i < list.Count; i++)
            {
                Assert.That(list[i], Is.SameAs(elements[i]));
            }
        }

        [Test]
        public void Indexer_GoingOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            var list = new DynamicList<string>();

            //Assert
            Assert.That(() => list[0], Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Indexer_NegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            var list = new DynamicList<string>();

            //Assert
            Assert.That(() => list[-5], Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void RemoveAt_RemoveElementAtIndex_Successful()
        {
            //Arrange
            var list = new DynamicList<string>();
            var numberOfElements = 10;
            var removeElementAtIndex = 5;
            var elements = new List<string>();

            for (var i = 0; i < numberOfElements; i++)
            {
                var currentElement = $"String{i}";
                list.Add(currentElement);
                elements.Add(currentElement);
            }

            //Assert
            var elementsToRemove = numberOfElements - removeElementAtIndex;
            for (var i = removeElementAtIndex; i < elementsToRemove; i++)
            {
                Assert.That(() => list[removeElementAtIndex], Is.SameAs(elements[i]));
                Assert.That(() => list.RemoveAt(removeElementAtIndex), Throws.Nothing);
                Assert.That(() => list.Count == --numberOfElements);
            }
        }

        [Test]
        public void RemoveAt_GoingOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            var list = new DynamicList<string>();

            //Assert
            Assert.That(() => list.RemoveAt(0), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void RemoveAt_NegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            //Arrange
            var list = new DynamicList<string>();

            //Assert
            Assert.That(() => list.RemoveAt(-5), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Indexer_ChangeElementAtIndex_Successful()
        {
            //Arrange
            var list = new DynamicList<string>();
            var originalElement = "Original Element";
            var newElement = "New Element";

            //Act
            list.Add(originalElement);
            list[0] = newElement;

            //Assert
            Assert.That(list[0], Is.SameAs(newElement));
        }

        [Test]
        public void Remove_RemoveGivenElement_SuccessfulAndReturnIndexOfRemovedElement()
        {
            //Arrange
            var list = new DynamicList<string>();
            var numberOfElements = 10;
            var removeGivenElementAtIndex = 5;
            var removeGivenElement = $"String{removeGivenElementAtIndex}";
            var elements = new List<string>();

            //Act
            for (var i = 0; i < numberOfElements; i++)
            {
                var currentElement = $"String{i}";
                list.Add(currentElement);
                elements.Add(currentElement);
            }

            var result = list.Remove(removeGivenElement);

            //Arrange
            Assert.That(elements[result], Is.EqualTo(removeGivenElement));
            Assert.That(result == removeGivenElementAtIndex);
        }

        [Test]
        public void Remove_ElementNotPresent_ReturnNegativeOne()
        {
            //Arrange
            var list = new DynamicList<string>();

            //Act
            var result = list.Remove("Neshto si");

            //Arrange
            Assert.That(result == -1);
        }

        [Test]
        public void IndexOf_IndexOFGivenElement_ReturnIndexOfGivenElement()
        {
            //Arrange
            var list = new DynamicList<string>();
            var numberOfElements = 10;
            var elementAtIndex = 5;
            var givenElement = $"String{elementAtIndex}";
            var elements = new List<string>();

            //Act
            for (var i = 0; i < numberOfElements; i++)
            {
                var currentElement = $"String{i}";
                list.Add(currentElement);
                elements.Add(currentElement);
            }

            var result = list.IndexOf(givenElement);

            //Arrange
            Assert.That(elements[result], Is.EqualTo(givenElement));
            Assert.That(result == elementAtIndex);
        }

        [Test]
        public void IndexOf_ElementNotPresent_ReturnNegativeOne()
        {
            //Arrange
            var list = new DynamicList<string>();

            //Act
            var result = list.IndexOf("Neshto si");

            //Arrange
            Assert.That(result == -1);
        }

        [Test]
        public void Contains_GivenElement_ReturnTrue()
        {
            //Arrange
            var list = new DynamicList<string>();
            var numberOfElements = 10;
            var elementAtIndex = 5;
            var givenElement = $"String{elementAtIndex}";

            //Act
            for (var i = 0; i < numberOfElements; i++)
            {
                var currentElement = $"String{i}";
                list.Add(currentElement);
            }

            //Arrange
            Assert.That(list.Contains(givenElement));
        }

        [Test]
        public void Contains_GivenElement_ReturnFalse()
        {
            //Arrange
            var list = new DynamicList<string>();

            //Arrange
            Assert.That(list.Contains("Neshto si"), Is.False);
        }
    }
}