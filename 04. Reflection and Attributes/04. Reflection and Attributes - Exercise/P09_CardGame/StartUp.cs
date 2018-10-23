namespace P09_CardGame
{
    using System;
    using Enums;

    public class StartUp
    {
        public static void Main()
        {
            var cardRanks = Enum.GetValues(typeof(CardRank));

            Console.WriteLine($"Card Ranks:");
            foreach (var cardRank in cardRanks)
            {
                Console.WriteLine($"Ordinal value: {(int)cardRank}; Name value: {cardRank}");
            }
        }
    }
}
