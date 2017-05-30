using System;

namespace _03.Problem
{
    public class StartUp
    {
        public static void Main()
        {
            var cardPower = new CardPower();

            var firstValue = Console.ReadLine();
            var secondValue = Console.ReadLine();

            var result = cardPower.GetRankValue((Rank)Enum.Parse(typeof(Rank), firstValue, true)) + 
                cardPower.GetSuitValue((Suit)Enum.Parse(typeof(Suit), secondValue, true));

            Console.WriteLine($"Card name: {firstValue} " +
                              $"of {secondValue}; Card power: {result}");
        }
    }
}
