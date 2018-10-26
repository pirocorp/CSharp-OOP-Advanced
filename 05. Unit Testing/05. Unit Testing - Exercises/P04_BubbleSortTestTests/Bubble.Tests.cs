namespace P04_BubbleSortTestTests
{
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using P04_BubbleSortTest;

    [TestFixture]
    public class BubbleTests
    {
        private int[] numbers;
        private Bubble<int> bubble;
        private int[] result;

        [SetUp]
        public void Initialize()
        {
            this.numbers = new[] { 19, 13, 47, 49, 21, 28, 47, 35, 24, 21, 23, 29, 23, 20, 10, 48, 6 };
            this.bubble = new Bubble<int>(this.numbers);
            this.result = new[] {6, 10, 13, 19, 20, 21, 21, 23, 23, 24, 28, 29, 35, 47, 47, 48, 49,};
        }

        [Test]
        public void Constructor_CreateInstance_Successful()
        {
            //Act
            var result = typeof(Bubble<int>)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(x => x.FieldType == typeof(int[]))
                .GetValue(this.bubble);

            //Assert
            Assert.That(result, Is.EquivalentTo(this.numbers));
        }

        [Test]
        public void Sort_SortingElements_Successful()
        {
            //Act
            var sorted = this.bubble.Sort();

            //Assert
            Assert.That(sorted, Is.EquivalentTo(this.result));
        }

        [TestCase(new int[0])]
        [TestCase(new[] { 1 })]
        [TestCase(new[] { 2, 1 })]
        [TestCase(new[] { 1, 2 })]
        [TestCase(new[] { 3, 1, 2 })]
        [TestCase(new[] { 3, 2, 1 })]
        [TestCase(new[] { 3, 3, 3 })]
        [TestCase(new[] { 2, 7, 9, 3, 4 })]
        [TestCase(new[] { 1, 7, 99, 2, 0, 12, 15 })]
        [TestCase(new[] { 8, 5, 3, 1, 9, 6, 0, 7, 4, 2, 5 })]
        [TestCase(new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
        [TestCase(new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 })]
        public void Sort_SortElements_Successful(int[] unsortedArray)
        {
            //Arrange
            var sortedArray = new Bubble<int>(unsortedArray).Sort().ToArray();

            //Assert
            for (var i = 0; i < sortedArray.Length - 1; i++)
            {
                Assert.That(sortedArray[i], Is.LessThanOrEqualTo(sortedArray[i + 1]));
            }

            Assert.That(sortedArray, Is.EquivalentTo(unsortedArray));
        }
    }
}