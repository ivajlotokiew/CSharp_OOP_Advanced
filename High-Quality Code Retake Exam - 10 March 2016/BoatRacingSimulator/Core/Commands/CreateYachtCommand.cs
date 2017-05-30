using System;
using BoatRacingSimulator.Interfaces;
using BoatRacingSimulator.Models.Boat;

namespace BoatRacingSimulator.Core.Commands
{
    public class CreateYachtCommand : Command
    {
        public CreateYachtCommand(string[] parameters, IBoatDatabase dataBase)
            : base(parameters, dataBase)
        {
        }

        public override string Execute()
        {
            string model = this.Parameters[0];
            int weight = int.Parse(this.Parameters[1]);
            string engineModel = this.Parameters[2];
            int cargoWeight = int.Parse(this.Parameters[3]);

            IBoatEngine engine = this.Database.Engines.GetItem(engineModel);
            IBoat boat = new Yacht(model, weight, cargoWeight, engine);
            this.Database.Boats.Add(boat);

            return string.Format("Yacht with model {0} registered successfully.", model);
        }
    }
}
