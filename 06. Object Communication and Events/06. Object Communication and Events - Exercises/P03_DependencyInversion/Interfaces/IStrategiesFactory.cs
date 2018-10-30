namespace P03_DependencyInversion.Interfaces
{
    public interface IStrategiesFactory
    {
        IStra CreateStrategy(char operatorType);
    }
}