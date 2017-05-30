using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Microsoft.Win32;
using _07.Problem.Interfaces;
using _07.Problem.Models;

namespace _07.Problem
{
    public class Program
    {
        public static void Main()
        {
            List<IUnit> units = new List<IUnit>();

            int numberOfUnits = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfUnits; i++)
            {
                string[] dataUnits = Console.ReadLine().Split(' ');
                string name = dataUnits[0];
                int age = int.Parse(dataUnits[1]);

                if (dataUnits.Length == 3)
                {
                    string group = dataUnits[2];

                    units.Add(new Rebel(name, age, group));
                }
                else
                {
                    string id = dataUnits[2];
                    string birthday = dataUnits[3];

                    units.Add(new Citizen(name, age, id, birthday));
                }
            }

            string foodBuyers = Console.ReadLine();

            while (foodBuyers != "End")
            {
                foreach (var unit in units)
                {
                    if (unit.Name == foodBuyers)
                    {
                        unit.BuyFood();
                    }
                }

                foodBuyers = Console.ReadLine();
            }

            int output = units.Sum(st => st.Food);

            Console.WriteLine(output);
        }
    }
}
