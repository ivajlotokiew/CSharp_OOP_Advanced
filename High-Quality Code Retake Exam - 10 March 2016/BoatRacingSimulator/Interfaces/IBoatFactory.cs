namespace BoatRacingSimulator.Interfaces
{
    public interface IBoatFactory
    {
        IBoat CreateBoat(string[] parameters);
    }
}
