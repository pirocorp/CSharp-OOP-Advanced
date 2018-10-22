namespace P07_InfernoInfinity.Models.Gems
{
    using GemMutators;

    public class Ruby : Gem
    {
        private const int STRENGTH = 7;
        private const int AGILITY = 2;
        private const int VITALITY = 5;

        public Ruby(QualityLevel qualityLevel = QualityLevel.Chipped) 
            : base(STRENGTH, AGILITY, VITALITY, qualityLevel)
        {
        }
    }
}