namespace _07.Problem.Models
{
    public class Rebel : Unit
    {
        public Rebel(string name, int age, string group)
            : base(name, age)
        {
            this.Group = group;
        }

        public string Group { get; }

        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
