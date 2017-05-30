namespace BoatRacingSimulator.Interfaces
{
    public interface IBoatDatabase
    {
        IRepository<IBoat> Boats { get; }

        IRepository<IBoatEngine> Engines { get; }

        IRace CurrentRace { get; set; }

        void ValidateRaceIsSet();

        void ValidateRaceIsEmpty();
    }
}
