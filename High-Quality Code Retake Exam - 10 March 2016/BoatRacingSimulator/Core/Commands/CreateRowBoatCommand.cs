namespace BoatRacingSimulator.Core.Commands
{
    using BoatRacingSimulator.Interfaces;
    using Models.Boat;

    public class CreateRowBoatCommand : Command
    {
        public CreateRowBoatCommand(string[] parameters, IBoatDatabase dataBase)
            : base(parameters, dataBase)
        {
        }

        public override string Execute()
        {
            string model = this.Parameters[0];
            int weight = int.Parse(this.Parameters[1]);
            int oars = int.Parse(this.Parameters[2]);
            IBoat boat = new RowBoat(model, weight, oars);
            this.Database.Boats.Add(boat);

            return string.Format("Row boat with model {0} registered successfully.", model);
        }
    }
}
