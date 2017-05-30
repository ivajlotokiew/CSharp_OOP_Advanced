using Problem2_KingGambit.Interfaces;

namespace Problem2_KingGambit.Models
{
    public abstract class Human : IName
    {
        protected Human(string name)
        {
            this.Name = name;
        }
        public string Name { get; }
    }
}