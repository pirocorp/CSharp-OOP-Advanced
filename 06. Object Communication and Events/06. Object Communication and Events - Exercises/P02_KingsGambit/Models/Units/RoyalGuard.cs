namespace P02_KingsGambit.Models.Units
{
    using Interfaces;
    using IO;

    public class RoyalGuard : Unit
    {
        private const int DEFAULT_HITS = 3;

        public RoyalGuard(string name)
            :this(new ConsoleWriter(), name)
        {

        }

        public RoyalGuard(IWriter writer, string name) 
            : base(writer, name, DEFAULT_HITS)
        {
        }

        public override void RespondToAttack()
        {
            if (this.IsAlive)
            {
                this.Writer.WriteLine($"Royal Guard {this.Name} is defending!");
            }
        }
    }
}