namespace BoatRacingSimulator.Models.Boat
{
    using Interfaces;
    using System;

    public class PowerBoat : Boat, IEngineHelder
    {
        private IBoatEngine firstEngine;
        private IBoatEngine secondEngine;

        public PowerBoat(string model, int weight, IBoatEngine firstEngine, IBoatEngine secondEngine)
            : base(model, weight)
        {
            this.firstEngine = firstEngine;
            this.secondEngine = secondEngine;
        }

        public IBoatEngine FirstEngine
        {
            get
            {
                return this.firstEngine;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public IBoatEngine SecondEngine
        {
            get
            {
                return this.secondEngine;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.firstEngine.Output + this.secondEngine.Output -
                this.Weight + (race.OceanCurrentSpeed / 5d);

            return speed;
        }
    }
}
