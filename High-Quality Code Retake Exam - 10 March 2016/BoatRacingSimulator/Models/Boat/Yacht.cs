namespace BoatRacingSimulator.Models.Boat
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;
    using System;

    public class Yacht : Boat, IEngineHelder
    {
        private int cargoWeight;
        private IBoatEngine engine;

        public Yacht(string model, int weight, int cargoWeight, IBoatEngine boatEngine)
            : base(model, weight)
        {
            this.CargoWeight = cargoWeight;
            this.Engine = boatEngine;
        }

        public IBoatEngine Engine
        {
            get
            {
                return this.engine;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.engine = value;
            }
        }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.engine.Output - (this.Weight +
                this.CargoWeight) + (race.OceanCurrentSpeed / 2d);

            return speed;
        }
    }
}