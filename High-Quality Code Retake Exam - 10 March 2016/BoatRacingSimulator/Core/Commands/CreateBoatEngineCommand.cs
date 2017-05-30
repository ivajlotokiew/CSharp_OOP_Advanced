namespace BoatRacingSimulator.Core.Commands
{
    using System;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models.BoatEngine;
    using BoatRacingSimulator.Enumerations;

    public class CreateBoatEngineCommand : Command
    {
        public CreateBoatEngineCommand(string[] parameters, IBoatDatabase dataBase, EngineType engineType)
            : base(parameters, dataBase)
        {
            this.EngineType = engineType;
        }

        public EngineType EngineType { get; private set; }

        public override string Execute()
        {
            IBoatEngine engine;
            string model = this.Parameters[0];
            int horsepower = int.Parse(Parameters[1]);
            int displacement = int.Parse(Parameters[2]);
            switch (EngineType)
            {
                case EngineType.Jet:
                    engine = new JetEngine(model, horsepower, displacement);
                    break;
                case EngineType.Sterndrive:
                    engine = new SterndriveEngine(model, horsepower, displacement);
                    break;
                default:
                    throw new NotImplementedException();
            }

            this.Database.Engines.Add(engine);

            return $"Engine model {model} with {horsepower} HP and " +
                $"displacement {displacement} cm3 created successfully.";
        }
    }
}
