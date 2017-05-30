using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stoneNumbers;

        public Lake()
        {
            this.stoneNumbers = new List<int>();
        }

        public void Add(int element)
        {
            this.stoneNumbers.Add(element);
        }

        public IEnumerator<int> GetEnumerator()
        {
            Stack<int> printNums = new Stack<int>();

            for (int i = 0; i < this.stoneNumbers.Count; i++)
            {
                if (i % 2 != 0)
                {
                    printNums.Push(this.stoneNumbers[i]);
                    continue;
                }

                yield return this.stoneNumbers[i];
            }

            while (printNums.Count > 0)
            {
                yield return printNums.Pop();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}