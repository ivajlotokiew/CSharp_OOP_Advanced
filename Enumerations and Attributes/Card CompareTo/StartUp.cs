using System;

namespace _03.Problem
{
    public class StartUp
    {
        public static void Main()
        {
            var cardPowerFirst = new CardPower
            {
                Rank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine(), true),
                Suit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine(), true)
            };


            var cardPowerSecond = new CardPower
            {
                Rank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine(), true),
                Suit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine(), true)
            };

            var result = cardPowerFirst.CompareTo(cardPowerSecond);

            Console.WriteLine(result > 0 ? $"{cardPowerFirst}" : $"{cardPowerSecond}");
        }
    }
}
