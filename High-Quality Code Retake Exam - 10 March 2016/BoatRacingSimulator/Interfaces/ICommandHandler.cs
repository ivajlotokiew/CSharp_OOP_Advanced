namespace BoatRacingSimulator.Interfaces
{
    public interface ICommandHandler
    {
        IExecutable ExecuteCommand(string name, string[] parameters);
    }
}
