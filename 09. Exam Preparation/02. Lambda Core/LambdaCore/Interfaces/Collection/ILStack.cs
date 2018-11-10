namespace LambdaCore.Interfaces.Collection
{
    using System.Collections.Generic;
    using Models;

    public interface ILStack
    {
        int Count();

        bool IsEmpty();

        IFragment Peek();

        void Pop();

        IFragment Push(IFragment item);

        IEnumerator<IFragment> GetEnumerator();

        IReadOnlyCollection<IFragment> Items { get; }
    }
}