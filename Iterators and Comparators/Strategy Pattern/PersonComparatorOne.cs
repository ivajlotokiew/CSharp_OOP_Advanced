using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public class PersonComparatorOne : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var lengthCompare = x.Name.Length.CompareTo(y.Name.Length);

            if (lengthCompare == 0)
            {
                var firstAlphabet = x.Name[0].ToString().ToLower().CompareTo(y.Name[0].ToString().ToLower());

                return firstAlphabet;
            }

            return lengthCompare;
        }
    }
}