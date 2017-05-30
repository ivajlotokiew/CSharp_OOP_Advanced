using BoatRacingSimulator.Interfaces;
using BoatRacingSimulator.Models;
using System;

namespace BoatRacingSimulator.Core.Commands
{
    public class OpenRaceCommand : Command
    {
        public OpenRaceCommand(string[] parameters, IBoatDatabase dataBase)
            : base(parameters, dataBase)
        {
        }

        public override string Execute()
        {
            int distance = int.Parse(this.Parameters[0]);
            int windSpeed = int.Parse(this.Parameters[1]);
            int oceanCurrentSpeed = int.Parse(this.Parameters[2]);
            bool allowsMotorboats = bool.Parse(this.Parameters[3]);

            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            this.Database.ValidateRaceIsEmpty();
            this.Database.CurrentRace = race;
            return
                string.Format(
                    "A new race with distance {0} meters, wind speed {1} " +
                    "m/s and ocean current speed {2} m/s has been set.",
                    distance, windSpeed, oceanCurrentSpeed);
        }
    }
}
