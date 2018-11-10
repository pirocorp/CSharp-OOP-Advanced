namespace LambdaCore.Models.Fragments
{
    using Enums;

    public class NuclearFragment : BaseFragment
    {
        private const int PRESSURE_AFFECTION_MULTIPLIER = 2;

        public NuclearFragment(string name, int pressureAffection)
            : base(name, pressureAffection * PRESSURE_AFFECTION_MULTIPLIER, FragmentType.Nuclear)
        {
        }
    }
}