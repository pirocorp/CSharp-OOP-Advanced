namespace LambdaCore.Interfaces.Models
{
    using System.Collections.Generic;

    public interface ICore
    {
        string Name { get; }

        int Durability { get; }

        IReadOnlyCollection<IFragment> Fragments { get; }

        void AddFragment(IFragment fragment);

        IFragment RemoveFragment();

        string Status { get; }
    }
}