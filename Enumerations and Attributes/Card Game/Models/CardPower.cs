using System;
using System.Runtime.Remoting.Channels;

namespace _03.Problem
{
    public class CardPower : IComparable<CardPower>
    {
        public CardPower(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public Rank Rank { get; set; }

        public Suit Suit { get; set; }

        public int SumOfPowerCards()
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