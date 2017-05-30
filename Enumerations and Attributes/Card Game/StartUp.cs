using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem
{
    public class StartUp
    {
        private static Stack<string> deck = new Stack<string>();
        public static void Main()
        {
            var cardGame = new Dictionary<string, List<CardPower>>();
            var counter = 0;
            var firstPlayer = Console.ReadLine();
            var secondPlayer = Console.ReadLine();

            cardGame.Add(firstPlayer, new List<CardPower>());
            cardGame.Add(secondPlayer, new List<CardPower>());

            CardsGameMethod(counter, cardGame, firstPlayer);
            counter = 0;
            CardsGameMethod(counter, cardGame, secondPlayer);

            GetMaxPointsPlayer(cardGame);
        }

        private static void GetMaxPointsPlayer(Dictionary<string,
            List<CardPower>> cardGame)
        {
            int playerPoints;
            int maxPlPoints = 0;
            string playerName = string.Empty;
            CardPower result = null;

            foreach (var points in cardGame)
            {
                playerPoints = points.Value.Select(st => st.SumOfPowerCards()).Max();
                if (maxPlPoints < playerPoints)
                {
                    maxPlPoints = playerPoints;
                    playerName = points.Key;
                    result = cardGame[playerName].FirstOrDefault(st => st.SumOfPowerCards() == maxPlPoints);
                }
            }

            Console.WriteLine($"{playerName} wins with " +
                              $"{result.Rank} of {result.Suit}.");
        }

        private static void CardsGameMethod(int counter,
            Dictionary<string, List<CardPower>> cardGame, string player)
        {
            Rank rankCard;
            Suit suitCard;

            while (counter < 5)
            {
                string line = Console.ReadLine();
                string[] cards = line
                    .Split(new[] { "of", " " }, StringSplitOptions.RemoveEmptyEntries);

                var rank = cards[0];
                var suit = cards[1];

                if (Enum.TryParse(rank, out rankCard))
                {
                    if (Enum.TryParse(suit, out suitCard))
                    {
                        var newCardPower = new CardPower((Rank)Enum.Parse(typeof(Rank), rank, true)
                            , (Suit)Enum.Parse(typeof(Suit), suit, true));

                        if (deck.Contains(line))
                        {
                            Console.WriteLine("Card is not in the deck.");
                            continue;
                        }

                        deck.Push(line);
                        counter++;
                        cardGame[player]
                            .Add(newCardPower);
                    }
                }
                else
                {
                    Console.WriteLine("No such card exists.");
                }
            }
        }
    }
}
