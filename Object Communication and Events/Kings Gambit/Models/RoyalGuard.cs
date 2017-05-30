using System;
using Problem2_KingGambit.Interfaces;

namespace Problem2_KingGambit.Models
{
    public class RoyalGuard : Human, IDieable, IReactToAttack
    {
        public RoyalGuard(string name)
             : base(name)
        {
            this.AmIKilled = false;
        }

        public bool AmIKilled { get; set; }

        public void ReactToAttack()
        {
            if (!this.AmIKilled)
            {
                Console.WriteLine($"Royal Guard {this.Name} is defending!");
            }
        }
    }
}