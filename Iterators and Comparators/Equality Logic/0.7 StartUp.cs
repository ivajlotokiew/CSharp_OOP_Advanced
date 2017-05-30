using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        public static void Main()
        {

            var sortedSetPersons = new SortedSet<Person>();
            var hashSetPersons = new HashSet<Person>();

            int numberOfPersons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPersons; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);

                sortedSetPersons.Add(new Person(name, age));
                hashSetPersons.Add(new Person(name, age));
            }

            Console.WriteLine(sortedSetPersons.Count);
            Console.WriteLine(hashSetPersons.Count);
        }
    }
}
