namespace LambdaCore.Interfaces.Core.FactoryHandlers
{
    using Models;

    public interface IFragmentsFactoryHandler
    {
        bool TryCreateFragment(string[] args, out IFragment newFragment);
    }
}