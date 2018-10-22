namespace P07_InfernoInfinity.Interfaces
{
    using Models.Gems.GemMutators;

    public interface IGem
    {
        int Strength { get; }

        int Agility { get; }

        int Vitality { get; }

        QualityLevel QualityLevel { get; }
    }
}
