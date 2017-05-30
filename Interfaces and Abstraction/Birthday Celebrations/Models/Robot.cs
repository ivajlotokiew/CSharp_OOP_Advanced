using Interfaces_and_Abstraction.Interfaces;

namespace Interfaces_and_Abstraction.Models
{
    public class Robot : IIdentified, IName
    {
        public Robot(string model, string id)
        {
            this.Name = model;
            this.Id = id;
        }

        public string Id { get; }

        public string Name { get; }
    }
}
