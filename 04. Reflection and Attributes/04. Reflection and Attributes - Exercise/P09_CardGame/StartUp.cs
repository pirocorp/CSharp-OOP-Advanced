namespace P09_CardGame
{
    using System;
    using Enums;

    public class StartUp
    {
        public static void Main()
        {
            var rankOfCardString = Console.ReadLine();
            var suitOfCardString = Console.ReadLine();

            var rankOfCard = Enum.Parse<CardRank>(rankOfCardString);
            var suitOfCard = Enum.Parse<CardSuit>(suitOfCardString);

            var card = new CardPower(rankOfCard, suitOfCard);
            Console.WriteLine($"Card name: {card.Name}; Card power: {card.Power}");
        }
    }
}
