namespace P09_CardGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;

    public class CardGameController
    {
        private readonly List<Card> playerOneHand;
        private readonly List<Card> playerTwoHand;
        private string playerOneName;
        private string playerTwoName;


        public CardGameController()
        {
            this.playerOneHand = new List<Card>();
            this.playerTwoHand = new List<Card>();
        }

        public void Run()
        {
            this.playerOneName = Console.ReadLine();
            this.playerTwoName = Console.ReadLine();

            this.ReadPlayerCards(this.playerOneHand);
            this.ReadPlayerCards(this.playerTwoHand);

            this.DetermineWinner();
        }

        private void DetermineWinner()
        {
            var playerOneBestCard = this.playerOneHand
                .OrderByDescending(x => x.Power)
                .First();

            var playerTwoBestCard = this.playerTwoHand
                .OrderByDescending(x => x.Power)
                .First();

            var comparator = playerOneBestCard.CompareTo(playerTwoBestCard);

            if (comparator > 0)
            {
                Console.WriteLine($"{this.playerOneName} wins with {playerOneBestCard}.");
            }
            else if (comparator < 0)
            {
                Console.WriteLine($"{this.playerTwoName} wins with {playerTwoBestCard}.");

            }
            else
            {
                Console.WriteLine($"Draw:{Environment.NewLine}PlayerOneCard: {playerOneBestCard}{Environment.NewLine}PlayerTwoCard: {playerTwoBestCard}");
            }
        }

        private void ReadPlayerCards(List<Card> playerHand)
        {
            while (playerHand.Count < 5)
            {
                var tokens = Console.ReadLine().Split(" of ");

                var rankAsString = tokens[0];
                var suitAsString = tokens[1];

                var rankIsParsed = Enum.TryParse(typeof(Rank), rankAsString, out var rankAsObject);
                var suitIsParsed = Enum.TryParse(typeof(Suit), suitAsString, out var suitAsObject);

                if (!rankIsParsed || !suitIsParsed)
                {
                    Console.WriteLine($"No such card exists.");
                    continue;
                }

                var rank = (Rank) rankAsObject;
                var suit = (Suit) suitAsObject;

                var currentCard = new Card(rank, suit);

                if (this.playerOneHand.Any(x => x.CompareTo(currentCard) == 0))
                {
                    Console.WriteLine($"Card is not in the deck.");
                    continue;
                }

                playerHand.Add(currentCard);
            }
        }
    }
}