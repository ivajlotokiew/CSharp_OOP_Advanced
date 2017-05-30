namespace BoatRacingSimulator.Core.Commands
{
    using BoatRacingSimulator.Interfaces;
    using System.Text;
    using System.Collections.Generic;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Utility;
    using System.Linq;

    public class StartRaceCommand : Command
    {
        public StartRaceCommand(string[] parameters, IBoatDatabase dataBase)
            : base(parameters, dataBase)
        {
        }

        public override string Execute()
        {
            this.Database.ValidateRaceIsSet();
            List<IBoat> participants = this.Database.CurrentRace.GetParticipants().ToList();
            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var first = this.FindFastest(participants);
            participants.Remove(first.Value);
            var second = this.FindFastest(participants);
            participants.Remove(second.Value);
            var third = this.FindFastest(participants);
            participants.Remove(third.Value);

            var result = new StringBuilder();
            result.AppendLine(string.Format(
                "First place: {0} Model: {1} Time: {2}",
                first.Value.GetType().Name,
                first.Value.Model,
                (first.Key < 0) ? "Did not finish!" : first.Key.ToString("0.00") + " sec"));
            result.AppendLine(string.Format(
                "Second place: {0} Model: {1} Time: {2}",
                second.Value.GetType().Name,
                second.Value.Model,
                (second.Key < 0) ? "Did not finish!" : second.Key.ToString("0.00") + " sec"));
            result.Append(string.Format(
                "Third place: {0} Model: {1} Time: {2}",
                third.Value.GetType().Name,
                third.Value.Model,
                (third.Key < 0) ? "Did not finish!" : third.Key.ToString("0.00") + " sec"));

            this.Database.CurrentRace = null;

            return result.ToString();
        }

        private KeyValuePair<double, IBoat> FindFastest(IList<IBoat> participants)
        {
            double bestTime = double.MaxValue;
            IBoat winner = null;
            foreach (var participant in participants)
            {
                var speed = participant.CalculateRaceSpeed(this.Database.CurrentRace);
                var time = this.Database.CurrentRace.Distance / speed;
                if (time < bestTime && time >= 0)
                {
                    bestTime = time;
                    winner = participant;
                }
            }

            if (bestTime == double.MaxValue)
            {
                winner = participants[0];
                bestTime = -1;
            }

            return new KeyValuePair<double, IBoat>(bestTime, winner);
        }
    }
}
