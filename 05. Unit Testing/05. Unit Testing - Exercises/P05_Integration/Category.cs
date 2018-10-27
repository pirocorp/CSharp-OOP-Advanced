namespace P05_Integration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Category : ICategory
    {
        private readonly IList<IUser> users;
        private readonly IList<ICategory> childCategories;
        private string name;

        public Category(string name)
            :this(name, null)
        {
        }

        public Category(string name, ICategory parentCategory)
            :this(name, new List<IUser>(), new List<ICategory>(), parentCategory)
        {
        }

        public Category(string name, IEnumerable<IUser> users, IEnumerable<ICategory> childCategories, ICategory parentCategory)
        {
            this.Name = name;
            this.users = new List<IUser>(users);
            this.childCategories = new List<ICategory>(childCategories);
            this.ParentCategory = parentCategory;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value ?? throw new ArgumentNullException();
        }

        public IEnumerable<IUser> Users => this.users;

        public IEnumerable<ICategory> Categories => this.childCategories;

        public ICategory ParentCategory { get; }

        public void AddUser(IUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.AddCategory(this);
            this.users.Add(user);
        }

        public void AddCategory(ICategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException();
            }

            var newSubCategory = new Category(category.Name, category.Users, category.Categories, this);
            this.childCategories.Add(newSubCategory);
        }

        public bool RemoveCategory(ICategory category)
        {
            if (!category.Categories.Any())
            {
                return this.childCategories.Remove(category);
            }

            if (category.Users.Count() != 0)
            {
                this.CopyUsersFromParentCategoryToItsChildCategory(category);
            }

            this.TransferSubCategoriesFromCategoryToBeMovedToThisCategories(category);
            this.RemoveCategoryFromUsers(category);
            return this.childCategories.Remove(category);
        }

        private void RemoveCategoryFromUsers(ICategory category)
        {
            var usersFromCategoryToBeRemoved = category.Users;

            foreach (var user in usersFromCategoryToBeRemoved)
            {
                user.RemoveCategory(category);
            }
        }

        private void TransferSubCategoriesFromCategoryToBeMovedToThisCategories(ICategory category)
        {
            var subCategories = category.Categories.ToArray();

            foreach (var subCat in subCategories)
            {
                var newSubCategory = new Category(subCat.Name, subCat.Users, subCat.Categories, category.ParentCategory);
                this.childCategories.Add(newSubCategory);
            }
        }

        private void CopyUsersFromParentCategoryToItsChildCategory(ICategory category)
        {
            var categoryUsers = category.Users.ToArray();
            var categorySubCategory = category.Categories;

            foreach (var child in categorySubCategory)
            {
                foreach (var user in categoryUsers)
                {
                    child.AddUser(user);
                }
            }
        }
    }
}