using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Problem2_KingGambit.Interfaces;
using Problem2_KingGambit.Models;

namespace Problem2_KingGambit
{
    public class Startup
    {
        public static void Main()
        {
            var kingdom = new List<Human>();

            string kingName = Console.ReadLine();
            kingdom.Add(new King(kingName));

            string[] royalGuards = Console.ReadLine().Split();
            kingdom.AddRange(royalGuards.Select(t => new RoyalGuard(t)));

            string[] footmans = Console.ReadLine().Split();
            kingdom.AddRange(footmans.Select(t => new FootMan(t)));

            string line = Console.ReadLine();

            while (line != "End")
            {
                string command = line.Split()[0];

                switch (command)
                {
                    case "Attack":
                        foreach (var human in kingdom)
                        {
                            if (human is RoyalGuard)
                            {
                                var unit = human as RoyalGuard;
                                unit.ReactToAttack();
                            }
                            else if (human is FootMan)
                            {
                                var unit = human as FootMan;
                                unit.ReactToAttack();
                            }
                            else
                            {
                                var unit = human as King;
                                unit.ReactToAttack();
                            }
                        }
                        break;
                    case "Kill":
                        string nameLuckyMan = line.Split()[1];
                        var chosen = kingdom.FirstOrDefault(st => st.Name == nameLuckyMan) as IDieable;
                        chosen.AmIKilled = true;
                      
                        break;
                }

                line = Console.ReadLine();
            }
        }
    }
}
