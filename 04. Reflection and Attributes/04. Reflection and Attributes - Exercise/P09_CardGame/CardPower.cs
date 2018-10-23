namespace P09_CardGame
{
    using System;
    using Enums;

    public class CardPower : IComparable<CardPower>
    {
        public CardPower(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public Rank Rank { get; }

        public Suit Suit { get; }

        public int Power => (int)this.Rank + (int)this.Suit;

        public string Name => $"{this.Rank} of {this.Suit}";

        public override string ToString()
        {
            return $"Card name: {this.Name}; Card power: {this.Power}";
        }


        public int CompareTo(CardPower other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            return this.Power.CompareTo(other.Power);
        }
    }
}