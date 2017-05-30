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
            List<IName> units = new List<IName>();
 //           bool isResult = false;

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] infoUnits = input.Split(' ');
                string unit = infoUnits[0];

                switch (unit)
                {
                    case "Pet":
                        string petName = infoUnits[1];
                        string petBirthdata = infoUnits[2];
                        units.Add(new Pet(petName, petBirthdata));
                        break;

                    case "Citizen":
                        string citizenName = infoUnits[1];
                        int age = int.Parse(infoUnits[2]);
                        string citizenId = infoUnits[3];
                        string citizenBirtdata = infoUnits[4];
                        units.Add(new Citizen(citizenName, age, citizenId, citizenBirtdata));
                        break;

                    case "Robot":
                        string robotModel = infoUnits[1];
                        string robotId = infoUnits[2];
                        units.Add(new Robot(robotModel, robotId));
                        break;
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();
            foreach (var unit in units)
            {
                if (unit is Citizen)
                {
                    var citizen = unit as Citizen;
                    if (citizen.Birthday.Contains(year))
                    {
    //                    isResult = true;
                        Console.WriteLine(citizen.Birthday);
                    }
                }
                else if (unit is Pet)
                {
                    var pet = unit as Pet;
                    if (pet.Birthday.Contains(year))
                    {
      //                  isResult = true;
                        Console.WriteLine(pet.Birthday);
                    }
                }
            }

//            if (!isResult)
//            {
//                Console.WriteLine("<no output>");
//            }
        }
    }
}
