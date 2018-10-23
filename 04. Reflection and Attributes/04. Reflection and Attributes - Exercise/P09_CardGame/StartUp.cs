namespace P09_CardGame
{
    using System;
    using Enums;

    public class StartUp
    {
        public static void Main()
        {
            var cardSuits = Enum.GetValues(typeof(CardSuits));
            foreach (var cardSuit in cardSuits)
            {
                Console.WriteLine($"Ordinal value: {(int)cardSuit}; Name value: {cardSuit}");
            }
        }
    }
}
