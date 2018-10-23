namespace P09_CardGame
{
    using Enums;

    public class CardPower
    {
        public CardPower(CardRank rank, CardSuit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public CardRank Rank { get; }

        public CardSuit Suit { get; }

        public int Power => (int)this.Rank + (int)this.Suit;

        public string Name => $"{this.Rank} of {this.Suit}";
    }
}