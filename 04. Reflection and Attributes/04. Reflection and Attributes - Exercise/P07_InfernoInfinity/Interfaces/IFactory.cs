namespace P07_InfernoInfinity.Interfaces
{
    public interface IFactory<T>
    {
        T Create(params string[] productType);
    }
}
