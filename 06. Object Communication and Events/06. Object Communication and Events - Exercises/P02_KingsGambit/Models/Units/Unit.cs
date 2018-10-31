namespace P02_KingsGambit.Models.Units
{
    using Interfaces;

    public abstract class Unit : IUnit
    {
        private bool isDead;
        private int hits;
        protected readonly IWriter Writer;

        protected Unit(IWriter writer, string name, int hits)
        {
            this.isDead = false;
            this.Writer = writer;
            this.Name = name;
            this.hits = hits;
        }

        public string Name { get; private set; }

        public bool IsAlive => !this.isDead;

        public void Kill()
        {
            this.hits -= 1;

            if (this.hits == 0)
            {
                this.isDead = true;
            }
        }

        public abstract void RespondToAttack();
    }
}