using System;

namespace _03.Problem
{
    public class CardPower
    {
        public Rank Rank { get; set; }

        public Suit Suit { get; set; }

        public int GetRankValue(Rank rankValue)
        {
            var value = (int) rankValue;

            return value;
        }

        public int GetSuitValue(Suit suitValue)
        {
            var value = (int) suitValue;

            return value;
        }
    }
}