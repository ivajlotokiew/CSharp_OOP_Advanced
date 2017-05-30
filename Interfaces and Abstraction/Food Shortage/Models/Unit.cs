using _07.Problem.Interfaces;

namespace _07.Problem.Models
{
    public abstract class Unit : IUnit
    {
        protected Unit(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }

        public int Food { get; protected set; }

        public string Name { get; }

        public int Age { get; }

        public abstract void BuyFood();
    }
}
