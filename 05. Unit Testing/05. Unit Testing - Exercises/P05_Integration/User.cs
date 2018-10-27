namespace P05_Integration
{
    using System;
    using System.Collections.Generic;

    public class User : IUser
    {
        private string name;
        private readonly IList<ICategory> categories;

        public User(string name)
        {
            this.Name = name;
            this.categories = new List<ICategory>();
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value ?? throw new ArgumentNullException();
        }

        public IEnumerable<ICategory> Categories => this.categories;

        public void AddCategory(ICategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException();
            }

            this.categories.Add(category);
        }

        public bool RemoveCategory(ICategory category)
        {
            if (category == null)
            {
                throw new ArgumentNullException();
            }

            return this.categories.Remove(category);
        }
    }
}