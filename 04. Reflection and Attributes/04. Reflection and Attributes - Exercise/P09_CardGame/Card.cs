namespace P09_CardGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Enums;

    public class Card : IComparable<Card>
    {
        private Dictionary<Suit, string> suits;
        private Dictionary<Rank, string> ranks;

        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
            this.InitializeSuitsDictionary();
            this.InitializeRanksDictionary();
        }

        public Rank Rank { get; }

        public Suit Suit { get; }

        public int Power => (int)this.Rank + (int)this.Suit;

        public string Name => $"{this.GetRankDisplayName()}{this.GetSuitDisplayName()}";

        public override string ToString()
        {
            return $"Card name: {this.Name}; Card power: {this.Power}";
        }

        public int CompareTo(Card other)
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

        private string GetSuitDisplayName()
        {
            return this.suits[this.Suit];
        }

        private string GetRankDisplayName()
        {
            return this.ranks[this.Rank];
        }

        private void InitializeSuitsDictionary()
        {
            //'\u2660', '\u2663', '\u2666', '\u2665'
            this.suits = new Dictionary<Suit, string>()
            {
                {Suit.Clubs, "\u2663" },
                {Suit.Diamonds, "\u2666" },
                {Suit.Hearts, "\u2665" },
                {Suit.Spades, "\u2660" }
            };
        }

        private void InitializeRanksDictionary()
        {
            this.ranks = new Dictionary<Rank, string>()
            {
                {Rank.Ace, "A" },
                {Rank.Two, "2" },
                {Rank.Three, "3" },
                {Rank.Four, "4" },
                {Rank.Five, "5" },
                {Rank.Six, "6" },
                {Rank.Seven, "7" },
                {Rank.Eight, "8" },
                {Rank.Nine, "9" },
                {Rank.Ten, "10" },
                {Rank.Jack, "J" },
                {Rank.Queen, "Q" },
                {Rank.King, "K" },
            };
        }
    }
}