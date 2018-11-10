namespace LambdaCore.Models.Cores
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Collection;
    using Constants;
    using Interfaces.Collection;
    using Interfaces.Models;

    public abstract class BaseCore : ICore
    {
        private string name;
        private int durability;
        private readonly ILStack fragments;

        protected BaseCore(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
            this.fragments = new LStack();
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public int Durability
        {
            get => this.RealDurability();
            private set
            {
                Validator.ValidateNonNegativeInt(value, nameof(this.Durability));
                this.durability = value;
            }
        }

        public IReadOnlyCollection<IFragment> Fragments => this.fragments.Items;

        public void AddFragment(IFragment fragment)
        {
            this.fragments.Push(fragment);
        }

        public IFragment RemoveFragment()
        {
            var removedFragment = this.fragments.Peek();
            this.fragments.Pop();
            return removedFragment;
        }

        public string Status => this.FragmentsPressureCumulativeEffect > 0 ? $" CRITICAL" : $" NORMAL";

        private int FragmentsPressureCumulativeEffect => this.fragments.Items.Sum(i => i.PressureAffection);

        private int RealDurability()
        {
            var realDurability = this.durability - this.FragmentsPressureCumulativeEffect;

            realDurability = Math.Max(0, realDurability);
            realDurability = Math.Min(this.durability, realDurability);

            return realDurability;
        }
    }
}