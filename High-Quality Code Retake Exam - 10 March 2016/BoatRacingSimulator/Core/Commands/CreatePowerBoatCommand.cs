namespace BoatRacingSimulator.Core.Commands
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models.Boat;

    public class CreatePowerBoatCommand : Command
    {
        public CreatePowerBoatCommand(string[] parameters, IBoatDatabase dataBase)
            : base(parameters, dataBase)
        {
        }

        public override string Execute()
        {
            string model = this.Parameters[0];
            int weight = int.Parse(this.Parameters[1]);
            string firstEngineModel = this.Parameters[2];
            string secondEngineModel = this.Parameters[3];

            IBoatEngine firstEngine = this.Database.Engines.GetItem(firstEngineModel);
            IBoatEngine secondEngine = this.Database.Engines.GetItem(secondEngineModel);
            IBoat boat = new PowerBoat(model, weight, firstEngine, secondEngine);
            this.Database.Boats.Add(boat);

            return string.Format("Power boat with model {0} registered successfully.", model);
        }
    }
}
