namespace Interfaces_and_Abstraction.Models
{
    public class Robot : Unit
    {
        private string model;

        public Robot(string model, string id)
            : base(id)
        {
            this.model = model;
        }
    }
}
