using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class StartUp
    {
        public static void Main()
        {
            var sortedSetByName = new SortedSet<Person>(new PersonComparatorOne());
            var sortedSetByAge = new SortedSet<Person>(new PersonComparatorTwo());

            var numLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numLines; i++)
            {
                string[] data = Console.ReadLine().Split();
                string name = data[0];
                int age = int.Parse(data[1]);

                sortedSetByName.Add(new Person(name, age));
                sortedSetByAge.Add(new Person(name, age));
            }

            foreach (var person in sortedSetByName)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }

            foreach (var person in sortedSetByAge)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}
