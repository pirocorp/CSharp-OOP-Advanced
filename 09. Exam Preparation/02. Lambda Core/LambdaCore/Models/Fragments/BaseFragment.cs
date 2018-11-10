namespace LambdaCore.Models.Fragments
{
    using Constants;
    using Enums;
    using Interfaces.Models;

    public abstract class BaseFragment : IFragment
    {
        private string name;
        private int pressureAffection;
        private FragmentType type;

        protected BaseFragment(string name, int pressureAffection, FragmentType type)
        {
            this.Name = name;
            this.PressureAffection = pressureAffection;
            this.Type = type;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public virtual int PressureAffection
        {
            get => this.pressureAffection;
            private set
            {
                Validator.ValidateNonNegativeInt(value, nameof(this.PressureAffection));
                this.pressureAffection = value;
            }
        }

        public FragmentType Type
        {
            get => this.type;
            private set => this.type = value;
        }
    }
}