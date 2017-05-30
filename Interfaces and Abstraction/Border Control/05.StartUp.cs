using System;
using System.Collections.Generic;
using Interfaces_and_Abstraction.Interfaces;
using Interfaces_and_Abstraction.Models;

namespace Interfaces_and_Abstraction
{
    public class Program
    {
        public static void Main()
        {
            List<IIdentified> units = new List<IIdentified>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] infoUnits = input.Split(' ');

                if (infoUnits.Length == 2)
                {
                    string model = infoUnits[0];
                    string id = infoUnits[1];

                    units.Add(new Robot(model, id));
                }
                else
                {
                    string name = infoUnits[0];
                    int age = int.Parse(infoUnits[1]);
                    string id = infoUnits[2];

                    units.Add(new Citizen(name, age, id));
                }

                input = Console.ReadLine();
            }

            string idIdentifier = Console.ReadLine();

            foreach (var unit in units)
            {
                int partOfID = unit.Id.Length;
                int lengthIdentifier = idIdentifier.Length;

                if (unit.Id.Substring(partOfID - lengthIdentifier, lengthIdentifier) == idIdentifier)
                {
                    Console.WriteLine(unit.Id);
                }
            }
        }
    }
}
