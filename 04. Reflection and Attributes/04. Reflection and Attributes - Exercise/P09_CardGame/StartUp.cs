namespace P09_CardGame
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Enums;

    public class StartUp
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var deckOfCards = GenerateDeckOfCards();
            var deckIndex = 0;

            for (var row = 0; row < 4; row++)
            {
                for (var col = 0; col < 13; col++)
                {
                    Console.Write($"{deckOfCards[deckIndex++].Name} ");
                }

                Console.WriteLine();
            }
        }

        private static Card[] GenerateDeckOfCards()
        {
            var deckOfCards = new Card[52];
            var deckIndex = 0;

            var ranks = GetRanks();
            var suits = Enum.GetValues(typeof(Suit));

            foreach (Suit suit in suits)
            {
                foreach (Rank rank in ranks)
                {
                    var currentCard = new Card(rank, suit);
                    deckOfCards[deckIndex++] = currentCard;
                }
            }

            return deckOfCards;
        }

        private static Rank[] GetRanks()
        {
            var ranksNotOrdered = Enum.GetValues(typeof(Rank));
            var ranks = new Rank[13];

            var rankIndex = 1;

            foreach (Rank rank in ranksNotOrdered)
            {
                if (rank != Rank.Ace)
                {
                    ranks[rankIndex++] = rank;
                }
            }

            ranks[0] = Rank.Ace;
            return ranks;
        }

        private static Card ReadCardFromConsole()
        {
            var rankOfCardString = Console.ReadLine();
            var suitOfCardString = Console.ReadLine();

            var rankOfCard = Enum.Parse<Rank>(rankOfCardString);
            var suitOfCard = Enum.Parse<Suit>(suitOfCardString);

            var card = new Card(rankOfCard, suitOfCard);

            return card;
        }
    }
}
