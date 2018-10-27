namespace P05_Integration.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;

    [TestFixture()]
    public class UserTests
    {
        [Test]
        public void Constructor_CreateUserInstance_Successful()
        {
            var userName = "Pesho";

            var user = new User(userName);

            Assert.That(user.Name, Is.EqualTo(userName));
        }

        [Test]
        public void Constructor_CreateUserWithNullName_TrowArgumentNullException()
        {
            string userName = null;

            Assert.That(() => new User(userName), Throws.ArgumentNullException);
        }

        [Test]
        public void AddCategory_AddingCategory_Successful()
        {
            var user = new User("Pesho");
            var category = new Mock<ICategory>();
            category.Setup(s => s.Name).Returns("TestCategory");

            user.AddCategory(category.Object);

            Assert.That(user.Categories.Count() == 1, Is.True);
            Assert.That(user.Categories.First().Name, Is.EqualTo("TestCategory"));
        }

        [Test]
        public void AddCategory_AddMultipleCategories_Successful()
        {
            var categoryCount = 10;
            var user = new User("Pesho");
            var resultAsString = new List<string>();

            for (var i = 0; i < categoryCount; i++)
            {
                var currentCategory = new Mock<ICategory>();
                currentCategory.Setup(s => s.Name).Returns($"Category{i}");
                user.AddCategory(currentCategory.Object);
                resultAsString.Add($"Category{i}");
            }

            Assert.That(user.Categories.Count() == categoryCount, Is.True);
            Assert.That(string.Join(", ", user.Categories.Select(x => x.Name)), Is.EqualTo(string.Join(", ", resultAsString)));
        }

        [Test]
        public void AddCategory_AddingNull_TrowArgumentNullException()
        {
            var user = new User("Pesho");

            Assert.That(() => user.AddCategory(null), Throws.ArgumentNullException);
        }

        [Test]
        public void RemoveCategory_TryingToRemoveNull_TrowArgumentNullException()
        {
            var user = new User("Pesho");

            Assert.That(() => user.RemoveCategory(null), Throws.ArgumentNullException);
        }

        [Test]
        public void RemoveCategory_SingleRemoveCategoryExists_ReturnsTrue()
        {
            var user = new User("Pesho");
            var category = new Mock<ICategory>();
            category.Setup(s => s.Name).Returns("TestCategory");

            user.AddCategory(category.Object);

            Assert.That(() => user.RemoveCategory(category.Object), Is.True);
            Assert.That(user.Categories.Count(), Is.EqualTo(0));
        }

        [Test]
        public void RemoveCategory_SingleRemoveCategoryNotExists_ReturnsFalse()
        {
            var categoryCount = 10;
            var user = new User("Pesho");
            for (var i = 0; i < categoryCount; i++)
            {
                var currentCategory = new Mock<ICategory>();
                currentCategory.Setup(s => s.Name).Returns($"Category{i}");
                user.AddCategory(currentCategory.Object);
            }
            var testCategory = new Mock<ICategory>();
            testCategory.Setup(s => s.Name).Returns($"Category{++categoryCount}");

            Assert.That(() => user.RemoveCategory(testCategory.Object), Is.False);
        }
    }
}