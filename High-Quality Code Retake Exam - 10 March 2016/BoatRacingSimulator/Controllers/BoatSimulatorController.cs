//namespace BoatRacingSimulator.Controllers
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Text;
//    using BoatRacingSimulator.Database;
//    using BoatRacingSimulator.Enumerations;
//    using BoatRacingSimulator.Exceptions;
//    using BoatRacingSimulator.Interfaces;
//    using BoatRacingSimulator.Models;
//    using BoatRacingSimulator.Utility;
//    using Models.BoatEngine;
//    using Models.Boat;

//    public class BoatSimulatorController : IBoatSimulatorController
//    {
//        public BoatSimulatorController(BoatDatabase database, IRace currentRace)
//        {
//            this.Database = database;
//            this.CurrentRace = currentRace;
//        }

//        public BoatSimulatorController()
//            : this(new BoatDatabase(), null)
//        {
//        }

//        public IRace CurrentRace { get; private set; }

//        public IBoatDatabase Database { get; private set; }

//        public string CreateBoatEngine(
//            string model, int horsepower, int displacement, EngineType engineType)
//        {
//            IBoatEngine engine;
//            switch (engineType)
//            {
//                case EngineType.Jet:
//                    engine = new JetEngine(model, horsepower, displacement);
//                    break;
//                case EngineType.Sterndrive:
//                    engine = new SterndriveEngine(model, horsepower, displacement);
//                    break;
//                default:
//                    throw new NotImplementedException();
//            }

//            this.Database.Engines.Add(engine);

//            return string.Format(
//                "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.",
//                model,
//                horsepower,
//                displacement);
//        }

//        public string CreateRowBoat(string model, int weight, int oars)
//        {
//            IBoat boat = new RowBoat(model, weight, oars);
//            this.Database.Boats.Add(boat);

//            return string.Format("Row boat with model {0} registered successfully.", model);
//        }

//        public string CreateSailBoat(string model, int weight, int sailEfficiency)
//        {
//            IBoat boat = new SailBoat(model, weight, sailEfficiency);
//            this.Database.Boats.Add(boat);

//            return string.Format("Sail boat with model {0} registered successfully.", model);
//        }

//        public string CreatePowerBoat(
//            string model, int weight, string firstEngineModel, string secondEngineModel)
//        {
//            IBoatEngine firstEngine = this.Database.Engines.GetItem(firstEngineModel);
//            IBoatEngine secondEngine = this.Database.Engines.GetItem(secondEngineModel);
//            IBoat boat = new PowerBoat(model, weight, firstEngine, secondEngine);
//            this.Database.Boats.Add(boat);
//            return string.Format("Power boat with model {0} registered successfully.", model);
//        }

//        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
//        {
//            IBoatEngine engine = this.Database.Engines.GetItem(engineModel);
//            IBoat boat = new Yacht(model, weight, cargoWeight, engine);
//            this.Database.Boats.Add(boat);

//            return string.Format("Yacht with model {0} registered successfully.", model);
//        }

//        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
//        {
//            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
//            this.ValidateRaceIsEmpty();
//            this.CurrentRace = race;
//            return
//                string.Format(
//                    "A new race with distance {0} meters, wind speed {1} " +
//                    "m/s and ocean current speed {2} m/s has been set.",
//                    distance, windSpeed, oceanCurrentSpeed);
//        }

//        public string SignUpBoat(string model)
//        {
//            IBoat boat = this.Database.Boats.GetItem(model);
//            this.ValidateRaceIsSet();

//            if (!this.CurrentRace.AllowsMotorboats && boat is IEngineHelder)
//            {
//                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
//            }

//            this.CurrentRace.AddParticipant(boat);

//            return string.Format("Boat with model {0} has signed up for the current Race.", model);
//        }

//        public string StartRace()
//        {
//            this.ValidateRaceIsSet();
//            List<IBoat> participants = this.CurrentRace.GetParticipants().ToList();
//            if (participants.Count < 3)
//            {
//                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
//            }

//            var first = this.FindFastest(participants);
//            participants.Remove(first.Value);
//            var second = this.FindFastest(participants);
//            participants.Remove(second.Value);
//            var third = this.FindFastest(participants);
//            participants.Remove(third.Value);

//            var result = new StringBuilder();
//            result.AppendLine(string.Format(
//                "First place: {0} Model: {1} Time: {2}",
//                first.Value.GetType().Name,
//                first.Value.Model,
//                (first.Key < 0) ? "Did not finish!" : first.Key.ToString("0.00") + " sec"));
//            result.AppendLine(string.Format(
//                "Second place: {0} Model: {1} Time: {2}",
//                second.Value.GetType().Name,
//                second.Value.Model,
//                (second.Key < 0) ? "Did not finish!" : second.Key.ToString("0.00") + " sec"));
//            result.Append(string.Format(
//                "Third place: {0} Model: {1} Time: {2}",
//                third.Value.GetType().Name,
//                third.Value.Model,
//                (third.Key < 0) ? "Did not finish!" : third.Key.ToString("0.00") + " sec"));

//            this.CurrentRace = null;

//            return result.ToString();
//        }

//        public string GetStatistic()
//        {
//            //TODO Bonus Task Implement me
//            throw new NotImplementedException();
//        }

//        private KeyValuePair<double, IBoat> FindFastest(IList<IBoat> participants)
//        {
//            double bestTime = double.MaxValue;
//            IBoat winner = null;
//            foreach (var participant in participants)
//            {
//                var speed = participant.CalculateRaceSpeed(this.CurrentRace);
//                var time = this.CurrentRace.Distance / speed;
//                if (time < bestTime && time >= 0)
//                {
//                    bestTime = time;
//                    winner = participant;
//                }
//            }

//            if (bestTime == double.MaxValue)
//            {
//                winner = participants[0];
//                bestTime = -1;
//            }

//            return new KeyValuePair<double, IBoat>(bestTime, winner);
//        }

//        private void ValidateRaceIsSet()
//        {
//            if (this.CurrentRace == null)
//            {
//                throw new NoSetRaceException(Constants.NoSetRaceMessage);
//            }
//        }

//        private void ValidateRaceIsEmpty()
//        {
//            if (this.CurrentRace != null)
//            {
//                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
//            }
//        }
//    }
//}
