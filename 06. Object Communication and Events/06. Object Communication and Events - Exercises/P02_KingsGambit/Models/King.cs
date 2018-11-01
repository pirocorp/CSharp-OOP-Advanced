namespace P02_KingsGambit.Models
{
    using Interfaces;

    public delegate void KingUnderAttackEventHandler();
    
    public class King : IKing
    {
        public event KingUnderAttackEventHandler KingUnderAttack;
        private readonly IWriter writer;

        public King(IWriter writer, string name)
        {
            this.writer = writer;
            this.Name = name;
        }

        public string Name { get; private set; }

        public bool IsAlive => true;

        public void OnKingUnderAttack()
        {
            this.writer.WriteLine($"King {this.Name} is under attack!");

            this.KingUnderAttack?.Invoke();
        }
    }
}