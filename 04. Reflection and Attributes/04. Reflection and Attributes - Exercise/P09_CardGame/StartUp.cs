namespace P09_CardGame
{
    using System;
    using Enums;

    public class StartUp
    {
        public static void Main()
        {
            var card1 = ReadCardFromConsole();
            var card2 = ReadCardFromConsole();

            Console.WriteLine(card1);
            Console.WriteLine(card2);
            Console.WriteLine();

            var result = card1.CompareTo(card2);

            if (result > 0)
            {
                Console.WriteLine(card1);
            }
            else
            {
                Console.WriteLine(card2);
            }
        }

        private static CardPower ReadCardFromConsole()
        {
            var rankOfCardString = Console.ReadLine();
            var suitOfCardString = Console.ReadLine();

            var rankOfCard = Enum.Parse<CardRank>(rankOfCardString);
            var suitOfCard = Enum.Parse<CardSuit>(suitOfCardString);

            var card = new CardPower(rankOfCard, suitOfCard);

            return card;
        }
    }
}
