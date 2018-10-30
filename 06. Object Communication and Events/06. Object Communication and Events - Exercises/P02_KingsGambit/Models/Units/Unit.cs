namespace P02_KingsGambit.Models.Units
{
    using Interfaces;

    public abstract class Unit : IUnit
    {
        private bool isDead;
        protected readonly IWriter Writer;

        protected Unit(IWriter writer, string name)
        {
            this.isDead = false;
            this.Writer = writer;
            this.Name = name;
        }

        public string Name { get; private set; }

        public bool IsAlive => !this.isDead;

        public void Kill()
        {
            this.isDead = true;
        }

        public abstract void RespondToAttack();
    }
}