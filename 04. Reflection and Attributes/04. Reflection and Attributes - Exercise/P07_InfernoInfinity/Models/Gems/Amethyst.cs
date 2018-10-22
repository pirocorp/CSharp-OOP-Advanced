namespace P07_InfernoInfinity.Models.Gems
{
    using GemMutators;

    public class Amethyst : Gem
    {
        private const int STRENGTH = 2;
        private const int AGILITY = 8;
        private const int VITALITY = 4;

        public Amethyst(QualityLevel qualityLevel = QualityLevel.Chipped) 
            : base(STRENGTH, AGILITY, VITALITY, qualityLevel)
        {
        }
    }
}