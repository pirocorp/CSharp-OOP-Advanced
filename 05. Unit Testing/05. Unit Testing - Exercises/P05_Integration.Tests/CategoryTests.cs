namespace P05_Integration.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void Constructor_SingleNameNull_ThrowArgumentNullException()
        {
            Assert.That(() => new Category(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Constructor_SingleName_CreateInstance()
        {
            const string categoryName = "Test Category";
            var category = new Category(categoryName);

            Assert.That(category.Name, Is.EqualTo(categoryName));
        }

        [Test]
        public void Constructor_NameAndParentCategory_CreateInstance()
        {
            const string categoryParentName = "Parent Category";
            const string testCategoryName = "Test Category";
            var parentCategory = new Category(categoryParentName);
            var testCategory = new Category(testCategoryName, parentCategory);

            Assert.That(testCategory.Name, Is.EqualTo(testCategoryName));
            Assert.That(testCategory.ParentCategory, Is.SameAs(parentCategory));
        }

        [Test]
        public void Constructor_AllItemsConstructor_CreateInstance()
        {
            const string testCategoryName = "Test Category";
            var parentCategory = new Mock<ICategory>();
            var users = new Mock<IList<IUser>>();
            var categories = new Mock<IList<ICategory>>();

            var testCategory = new Category(testCategoryName, users.Object, categories.Object, parentCategory.Object);

            Assert.That(testCategory.ParentCategory, Is.SameAs(parentCategory.Object));
            Assert.That(testCategory.Name, Is.EqualTo(testCategoryName));
        }

        [Test]
        public void Constructor_AllItemsNullExceptName_CreateInstance()
        {
            const string testCategoryName = "Test Category";

            Assert.That(() => new Category(testCategoryName, null, null, null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddUser_AddNull_ThrowArgumentNullException()
        {
            var category = new Category("Test");

            Assert.That(() => category.AddUser(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddUser_AddMultiple_Success()
        {
            var numberOfTestUsers = 10;

            var category = new Category("Test");
            var users = new List<User>();

            for (var i = 0; i < numberOfTestUsers; i++)
            {
                var currentUser = new User($"User{i}");
                users.Add(currentUser);
                Assert.That(() => category.AddUser(currentUser), Throws.Nothing);
            }

            var categoryUsers = category.Users.ToArray();

            for (var i = 0; i < categoryUsers.Length; i++)
            {
                Assert.That(categoryUsers[i], Is.SameAs(users[i]));
            }
        }

        [Test]
        public void AddCategory_AddNull_ThrowArgumentNullException()
        {
            var category = new Category("Test");

            Assert.That(() => category.AddCategory(null), Throws.ArgumentNullException);
        }

        [Test]
        public void AddCategory_AddMultiple_Success()
        {
            const int numberOfTestUsers = 10;

            var categoryRoot = new Category("Test");
            var categories = new List<Category>();

            for (var i = 0; i < numberOfTestUsers; i++)
            {
                var currentCategory = new Category($"Category{i}");
                categories.Add(currentCategory);
                Assert.That(() => categoryRoot.AddCategory(currentCategory), Throws.Nothing);
            }

            var subCategories = categoryRoot.Categories.ToArray();

            for (var i = 0; i < subCategories.Length; i++)
            {
                Assert.That(subCategories[i].ParentCategory, Is.Not.SameAs(categories[i].ParentCategory));
                Assert.That(subCategories[i].Name, Is.SameAs(categories[i].Name));
            }
        }

        [Test]
        public void RemoveCategoryFromUsers_CreateCategoryWithListOfUsers_Success()
        {
            //Arrange
            const int usersCount = 10;
            var category = new Category("Test");

            for (var i = 0; i < usersCount; i++)
            {
                var currentUser = new User($"Name{i}");
                category.AddUser(currentUser);
            }

            //Act
            var method = typeof(Category)
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "RemoveCategoryFromUsers");

            method.Invoke(category, new[] {category});

            //Assert
            foreach (var categoryUser in category.Users)
            {
                Assert.That(categoryUser.Categories.Any(x => x.Categories.All(y => y.Name != category.Name)), Is.False);
            }
        }

        [Test]
        public void TransferSubCategoriesFromCategoryToBeMovedToThisCategories_CreateCategoryWithSubDirectoryWithListOfSubCategories_Success()
        {
            //Arrange
            const int subCategoriesCount = 20;
            var category = new Category("Test");
            var subCategory = new Category("Sub Category");
            category.AddCategory(subCategory);

            for (var i = 0; i < subCategoriesCount; i++)
            {
                var currentCategory = new Category($"Category{i}");
                category.Categories.First().AddCategory(currentCategory);
            }

            //Act
            var method = typeof(Category)
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "TransferSubCategoriesFromCategoryToBeMovedToThisCategories");

            method.Invoke(category, new[] { category.Categories.First() });

            //Assert
            Assert.That(category.Categories.Count(), Is.EqualTo(subCategoriesCount + 1));
        }

        [Test]
        public void
            CopyUsersFromParentCategoryToItsChildCategory_CreateParentCategoryWithCoupleOfChildCategoryAndUsers_Success()
        {
            //Arrange
            const int subCategoriesCount = 10;
            const int numberOfUsers = 20;

            var rootCategory = new Category("Root Category");

            for (var i = 0; i < numberOfUsers; i++)
            {
                var currentUser = new User($"User{i}");
                rootCategory.AddUser(currentUser);
            }

            for (var i = 0; i < subCategoriesCount; i++)
            {
                var currentCategory = new Category($"Category{i}");
                rootCategory.AddCategory(currentCategory);
            }

            //Act
            var method = typeof(Category)
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.Name == "CopyUsersFromParentCategoryToItsChildCategory");

            method.Invoke(rootCategory, new[] {rootCategory});

            //Assert
            Assert.That(rootCategory.Categories.All(x => x.Users.Count() == numberOfUsers), Is.True);
        }

        [Test]
        public void RemoveCategory_RemoveSubCategory_ItSubCategoryRemainsAndUsersAreTransferetToItsSubCategories()
        {
            //Arrange
            const int subCategories = 2;
            const int numberOfUsers = 5;

            var rootCategory = new Category("Root Category");
            var categoryToBeRemoved = new Category("To Be Removed");

            for (var i = 0; i < numberOfUsers; i++)
            {
                var currentUser = new User($"User{i}");
                categoryToBeRemoved.AddUser(currentUser);
            }

            for (var i = 0; i < subCategories; i++)
            {
                var currentCategory = new Category($"Category{i}");
                categoryToBeRemoved.AddCategory(currentCategory);
            }

            rootCategory.AddCategory(categoryToBeRemoved);

            var listWithAllSubCategories = (IList<ICategory>) typeof(Category)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(IList<ICategory>))
                .GetValue(rootCategory);

            categoryToBeRemoved = (Category)listWithAllSubCategories
                .First(x => x.Name == categoryToBeRemoved.Name);

            //Act
            rootCategory.RemoveCategory(categoryToBeRemoved);

            //Assert
            Assert.That(rootCategory.Categories.Count() == subCategories, Is.True);
            Assert.That(rootCategory.Categories.All(x => x.Users.Count() == numberOfUsers), Is.True);
        }

        [Test]
        public void RemoveCategory_RemoveSubCategoryWithDeeperTree_Success()
        {
            //Arrange
            const int subCategoriesLevels = 2;
            const int numberOfUsers = 5;

            var rootCategory = new Category("Root Category");
            var categoryToBeRemoved = new Category("To Be Removed");
            categoryToBeRemoved.AddCategory(new Category("Category X"));

            for (var i = 0; i < numberOfUsers; i++)
            {
                var currentUser = new User($"User{i}");
                categoryToBeRemoved.AddUser(currentUser);
            }

            ICategory nextLevel = categoryToBeRemoved;

            for (var i = 0; i < subCategoriesLevels; i++)
            {
                var currentCategory = new Category($"Category{i}");
                nextLevel.AddCategory(currentCategory);
                nextLevel = nextLevel.Categories.First();
                nextLevel.AddCategory(new Category($"DeeperCategory{i}"));
            }

            rootCategory.AddCategory(categoryToBeRemoved);

            var listWithAllSubCategories = (IList<ICategory>)typeof(Category)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(x => x.FieldType == typeof(IList<ICategory>))
                .GetValue(rootCategory);

            categoryToBeRemoved = (Category)listWithAllSubCategories
                .First(x => x.Name == categoryToBeRemoved.Name);

            //Act
            rootCategory.RemoveCategory(categoryToBeRemoved);

            Assert.That(rootCategory.Categories.Count() == subCategoriesLevels);
            Assert.That(rootCategory.Categories.First().Categories.Count() == subCategoriesLevels);
            Assert.That(rootCategory.Categories.First().Categories.First().Categories.Count() == 1);
        }
    }
}