using System;
using BoatRacingSimulator.Interfaces;

namespace BoatRacingSimulator.Core.Commands
{
    public abstract class Command : IExecutable
    {
        public Command(string[] parameters, IBoatDatabase dataBase)
        {
            this.Database = dataBase;
            this.Parameters = parameters;
        }

        public string[] Parameters { get; private set; }

        public IBoatDatabase Database { get; set; }

        public abstract string Execute();
    }
}
