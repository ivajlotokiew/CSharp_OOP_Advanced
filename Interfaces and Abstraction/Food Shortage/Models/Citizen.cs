namespace _07.Problem.Models
{
    public class Citizen : Unit
    {
        public Citizen(string name, int age, string id, string birthday)
            : base(name, age)
        {
            this.ID = id;
            this.Birthday = birthday;
        }

        public string ID { get; }

        public string Birthday { get; }

        public override void BuyFood()
        {
            base.Food += 10;
        }
    }
}
