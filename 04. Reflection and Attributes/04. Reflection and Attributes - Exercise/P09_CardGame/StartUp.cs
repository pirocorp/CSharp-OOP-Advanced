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
            var typeString = Console.ReadLine();

            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == typeString);

            var attribute = type.GetCustomAttributes().FirstOrDefault();

            Console.WriteLine(attribute);
        }

        private static CardPower ReadCardFromConsole()
        {
            var rankOfCardString = Console.ReadLine();
            var suitOfCardString = Console.ReadLine();

            var rankOfCard = Enum.Parse<Rank>(rankOfCardString);
            var suitOfCard = Enum.Parse<Suit>(suitOfCardString);

            var card = new CardPower(rankOfCard, suitOfCard);

            return card;
        }
    }
}
