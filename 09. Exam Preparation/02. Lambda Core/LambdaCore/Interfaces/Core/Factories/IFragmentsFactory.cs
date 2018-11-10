namespace LambdaCore.Interfaces.Core.Factories
{
    using Models;

    public interface IFragmentsFactory
    {
        IFragment CreateFragment(string[] args);
    }
}