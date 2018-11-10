namespace LambdaCore.Models.Cores
{
    public class ParaCore : BaseCore
    {
        private const int DURABILITY_MODIFIER = 3;

        public ParaCore(string name, int durability)
            : base(name, durability / DURABILITY_MODIFIER)
        {
        }
    }
}