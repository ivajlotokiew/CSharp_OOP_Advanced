using System;
using BoatRacingSimulator.Interfaces;

namespace BoatRacingSimulator.Core.Factories.BoatFactory
{
    public abstract class BoatFactory : IBoatFactory
    {
        public abstract IBoat CreateBoat(string[] parameters);
    }
}
