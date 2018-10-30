namespace P02_KingsGambit.Models.Units
{
    using Interfaces;

    public class RoyalGuard : Unit
    {
        public RoyalGuard(IWriter writer, string name) 
            : base(writer, name)
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