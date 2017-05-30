using System;
using BoatRacingSimulator.Interfaces;
using BoatRacingSimulator.Utility;

namespace BoatRacingSimulator.Core.Commands
{
    public class SignUpBoatCommand : Command
    {
        public SignUpBoatCommand(string[] parameters, IBoatDatabase dataBase) 
            : base(parameters, dataBase)
        {
        }

        public override string Execute()
        {
            string model = this.Parameters[0];
            IBoat boat = this.Database.Boats.GetItem(model);
            this.Database.ValidateRaceIsSet();

            if (!this.Database.CurrentRace.AllowsMotorboats && boat is IEngineHelder)
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }

            this.Database.CurrentRace.AddParticipant(boat);

            return string.Format("Boat with model {0} has signed up for the current Race.", model);
        }
    }
}
