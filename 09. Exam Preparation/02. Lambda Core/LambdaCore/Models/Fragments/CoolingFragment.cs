namespace LambdaCore.Models.Fragments
{
    using Enums;

    public class CoolingFragment : BaseFragment
    {
        private const int PRESSURE_AFFECTION_MULTIPLIER = 3;

        public CoolingFragment(string name, int pressureAffection)
            : base(name, pressureAffection * PRESSURE_AFFECTION_MULTIPLIER, FragmentType.Cooling)
        {
        }

        public override int PressureAffection => - base.PressureAffection;
    }
}