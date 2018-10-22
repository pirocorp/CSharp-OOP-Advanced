namespace P07_InfernoInfinity.Models.Gems
{
    using GemMutators;

    public class Emerald : Gem
    {
        private const int STRENGTH = 1;
        private const int AGILITY = 4;
        private const int VITALITY = 9;

        public Emerald(QualityLevel qualityLevel = QualityLevel.Chipped) 
            : base(STRENGTH, AGILITY, VITALITY, qualityLevel)
        {
        }
    }
}