using System.Collections.Generic;

namespace P05_Integration
{
    public interface ICategory
    {
        IEnumerable<ICategory> Categories { get; }
        string Name { get; }
        ICategory ParentCategory { get; }
        IEnumerable<IUser> Users { get; }

        void AddCategory(ICategory category);
        void AddUser(IUser user);
        bool RemoveCategory(ICategory category);
    }
}