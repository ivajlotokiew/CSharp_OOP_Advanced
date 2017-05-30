using System;
using Problem2_KingGambit.Interfaces;

namespace Problem2_KingGambit.Models
{
    public class FootMan : Human, IDieable, IReactToAttack
    {
        public FootMan(string name)
            : base(name)
        {
            this.AmIKilled = false;
        }

        public bool AmIKilled { get; set; }

        public void ReactToAttack()
        {
            if (!this.AmIKilled)
            {
                Console.WriteLine($"Footman {this.Name} is panicking!");
            }
        }
    }
}