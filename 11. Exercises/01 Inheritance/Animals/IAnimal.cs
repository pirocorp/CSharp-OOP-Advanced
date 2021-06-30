namespace Animals
{
    public interface IAnimal
    {
        string Name { get; }

        int Age { get; }

        string Gender { get; }

        string AnimalType { get; }

        string ProduceSound();
    }
}
