using System;

namespace _03.Problem
{
    public class CardPower : IComparable<CardPower>
    {
        public Rank Rank { get; set; }

        public Suit Suit { get; set; }

        private int SumOfPowerCards()
        {
            var result = (int)this.Rank + (int)this.Suit;

            return result;
        }

        public int CompareTo(CardPower other)
        {
            return this.SumOfPowerCards().CompareTo(other.SumOfPowerCards());
        }

        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.SumOfPowerCards()}";
        }
    }
}