using System.Collections.Generic;

namespace P05_Integration
{
    public interface IUser
    {
        IEnumerable<ICategory> Categories { get; }
        string Name { get; }

        void AddCategory(ICategory category);
        bool RemoveCategory(ICategory category);
    }
}