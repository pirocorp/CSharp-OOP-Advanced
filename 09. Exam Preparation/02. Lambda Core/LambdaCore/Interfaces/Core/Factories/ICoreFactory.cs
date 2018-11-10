namespace LambdaCore.Interfaces.Core.Factories
{
    using Models;

    public interface ICoreFactory
    {
        ICore CreateCore(char coreName, string[] args);
    }
}