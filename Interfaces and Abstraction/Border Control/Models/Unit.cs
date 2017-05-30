using Interfaces_and_Abstraction.Interfaces;

namespace Interfaces_and_Abstraction.Models
{
    public abstract class Unit : IIdentified
    {
        protected Unit(string id)
        {
            this.Id = id;
        }

        public string Id { get; }
    }
}
