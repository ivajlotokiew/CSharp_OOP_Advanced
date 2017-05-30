using System.Collections.Generic;

namespace StrategyPattern
{
    public class PersonComparatorTwo : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var comareByAge = x.Age.CompareTo(y.Age);

            return comareByAge;
        }
    }
}