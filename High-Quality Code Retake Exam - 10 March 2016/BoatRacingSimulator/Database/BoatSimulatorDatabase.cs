namespace BoatRacingSimulator.Database
{
    using BoatRacingSimulator.Interfaces;
    using Exceptions;
    using Utility;

    public class BoatDatabase : IBoatDatabase
    {
        private IRace currentRace;

        public BoatDatabase()
        {
            this.Boats = new Repository<IBoat>();
            this.Engines = new Repository<IBoatEngine>();
        }

        public IRepository<IBoat> Boats { get; private set; }

        public IRepository<IBoatEngine> Engines { get; private set; }

        public IRace CurrentRace
        {
            get
            {
                return this.currentRace;
            }
            set
            {
                this.currentRace = value;

            }
        }

        public void ValidateRaceIsSet()
        {
            if (this.CurrentRace == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        public void ValidateRaceIsEmpty()
        {
            if (this.CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }
    }
}
