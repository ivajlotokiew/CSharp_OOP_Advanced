namespace BoatRacingSimulator.Core.Commands
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models.Boat;

    public class CreateSailBoatCommand : Command
    {
        public CreateSailBoatCommand(string[] parameters, IBoatDatabase dataBase)
            : base(parameters, dataBase)
        {
        }

        public override string Execute()
        {
            string model = this.Parameters[0];
            int weight = int.Parse(this.Parameters[1]);
            int sailEfficiency = int.Parse(this.Parameters[2]);
            IBoat boat = new SailBoat(model, weight, sailEfficiency);
            this.Database.Boats.Add(boat);

            return string.Format("Sail boat with model {0} registered successfully.", model);
        }
    }
}