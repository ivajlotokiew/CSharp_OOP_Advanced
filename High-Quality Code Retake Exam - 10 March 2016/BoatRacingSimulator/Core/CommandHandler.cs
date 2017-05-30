namespace BoatRacingSimulator.Core
{
    using System;
    using BoatRacingSimulator.Enumerations;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;
    using Commands;

    public class CommandHandler : ICommandHandler
    {
        public CommandHandler(IBoatDatabase database)
        {
            this.Database = database;
        }

        public IBoatDatabase Database { get; set; }

        public IExecutable ExecuteCommand(string name, string[] parameters)
        {
            switch (name)
            {
                case "CreateBoatEngine":
                    EngineType engineType;
                    if (Enum.TryParse(parameters[3], out engineType))
                    {
                        return new CreateBoatEngineCommand(parameters, Database, engineType);
                    }

                    throw new ArgumentException(Constants.IncorrectEngineTypeMessage);
                case "CreateRowBoat":
                    return new CreateRowBoatCommand(parameters, Database);
                case "CreateSailBoat":
                    return new CreateSailBoatCommand(parameters, Database);
                case "CreatePowerBoat":
                    return new CreatePowerBoatCommand(parameters, Database);
                case "CreateYacht":
                    return new CreateYachtCommand(parameters, Database);
                case "OpenRace":
                    return new OpenRaceCommand(parameters, Database);
                case "SignUpBoat":
                    return new SignUpBoatCommand(parameters, Database);
                case "StartRace":
                    return new StartRaceCommand(parameters, Database);
                //case "GetStatistic":
                //    return this.Controller.GetStatistic();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}