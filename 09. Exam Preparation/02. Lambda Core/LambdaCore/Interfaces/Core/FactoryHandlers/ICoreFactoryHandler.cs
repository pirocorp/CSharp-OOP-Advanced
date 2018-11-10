namespace LambdaCore.Interfaces.Core.FactoryHandlers
{
    using Models;

    public interface ICoreFactoryHandler
    {
        string CreateCore(char coreName, string[] args, out ICore newCore);
    }
}