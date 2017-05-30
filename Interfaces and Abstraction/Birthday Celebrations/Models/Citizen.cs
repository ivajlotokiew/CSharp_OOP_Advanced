using Interfaces_and_Abstraction.Interfaces;

namespace Interfaces_and_Abstraction.Models
{
    public class Citizen : BiologicalUnit, IIdentified
    {
        public Citizen(string name, int age, string id, string birthday)
            : base(name, birthday)
        {
            this.Age = age;
            this.Id = id;
        }

        public int Age { get; set; }

        public string Id { get; }
    }
}
