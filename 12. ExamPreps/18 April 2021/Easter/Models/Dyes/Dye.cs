namespace Easter.Models.Dyes
{
    using System;
    using Contracts;

    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            this.power = power;
        }

        public int Power
        {
            get => this.power;
            private set => this.power = Math.Max(0, value);
        }

        public void Use()
        {
            this.Power -= 10;
        }

        public bool IsFinished() => this.Power == 0;
    }
}
