namespace BoatRacingSimulator
{
    using BoatRacingSimulator.Core;
    using Database;
    using Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            IBoatDatabase database = new BoatDatabase();
            ICommandHandler commandHandler = new CommandHandler(database);
            var engine = new Engine(commandHandler);
            engine.Run();
        }
    }
}
