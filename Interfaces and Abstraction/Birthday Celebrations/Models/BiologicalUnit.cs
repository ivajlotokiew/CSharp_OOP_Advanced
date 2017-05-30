using Interfaces_and_Abstraction.Interfaces;

namespace Interfaces_and_Abstraction.Models
{
    public abstract class BiologicalUnit : IBorn, IName
    {
        protected BiologicalUnit(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Birthday { get; }

        public string Name { get; }
    }
}