using System;

namespace _03.Problem
{
    public class StartUp
    {
        public static void Main()
        {
            var cardPower = new CardPower();

            cardPower.Rank = (Rank)Enum.Parse(typeof(Rank), Console.ReadLine(), true);
            cardPower.Suit = (Suit)Enum.Parse(typeof(Suit), Console.ReadLine(), true);


            Console.WriteLine(cardPower);
        }
    }
}
