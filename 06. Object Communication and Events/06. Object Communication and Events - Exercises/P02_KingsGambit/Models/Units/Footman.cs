namespace P02_KingsGambit.Models.Units
{
    using Interfaces;
    using IO;

    public class Footman : Unit
    {
        private const int DEFAULT_HITS = 2;

        public Footman(string name) 
            :this(new ConsoleWriter(), name)
        {

        }

        public Footman(IWriter writer, string name) 
            : base(writer, name, DEFAULT_HITS)
        {
        }

        public override void RespondToAttack()
        {
            if (this.IsAlive)
            {
                this.Writer.WriteLine($"Footman {this.Name} is panicking!");
            }
        }
    }
}