namespace P02_KingsGambit.Models.Units
{
    using Interfaces;

    public class Footman : Unit
    {
        public Footman(IWriter writer, string name) 
            : base(writer, name)
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