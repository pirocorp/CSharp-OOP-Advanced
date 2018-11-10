namespace LambdaCore.Interfaces.Controllers
{
    public interface ILambdaCoreController
    {
        string AttachFragment(string[] args);

        string CreateCore(string[] args);

        string DetachFragment(string[] args);

        string RemoveCore(string[] args);

        string SelectCore(string[] args);

        string Status(string[] args);
    }
}