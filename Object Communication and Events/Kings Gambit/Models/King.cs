using System;
using Problem2_KingGambit.Interfaces;

namespace Problem2_KingGambit.Models
{
    public class King : Human, IReactToAttack
    {
        public King(string name) 
            : base(name)
        {
        }

        public void ReactToAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
        }
    }
}