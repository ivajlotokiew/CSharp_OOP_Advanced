namespace Interfaces_and_Abstraction.Models
{
    public class Citizen : Unit
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id)
            : base(id)
        {
            this.name = name;
            this.age = age;
        }
    }
}
