using System;
using System.Linq;

namespace _01.Problem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var values = Enum.GetValues(typeof(CardSuit));
            string cardSuits = Console.ReadLine();
            Console.WriteLine($"{cardSuits}:");

            foreach (var value in values)
            {
                Console.WriteLine($"Ordinal value: {(int)value}; Name value: {value}");
            }
        }
    }
}
