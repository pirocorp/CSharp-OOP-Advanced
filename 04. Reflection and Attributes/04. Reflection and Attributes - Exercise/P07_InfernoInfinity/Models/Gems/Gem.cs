namespace P07_InfernoInfinity.Models.Gems
{
    using GemMutators;
    using Interfaces;

    public abstract class Gem : IGem
    {
        private readonly int strength;
        private readonly int agility;
        private readonly int vitality;
        private readonly QualityLevel qualityLevel;

        protected Gem(int strength, int agility, int vitality, QualityLevel qualityLevel = QualityLevel.Chipped)
        {
            this.strength = strength;
            this.agility = agility;
            this.vitality = vitality;
            this.qualityLevel = qualityLevel;
        }

        public int Strength => this.strength + (int) this.QualityLevel;

        public int Agility => this.agility + (int) this.QualityLevel;

        public int Vitality => this.vitality + (int) this.QualityLevel;

        public QualityLevel QualityLevel => this.qualityLevel;
    }
}