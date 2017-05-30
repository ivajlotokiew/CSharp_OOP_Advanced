using System;
using System.Collections;
using System.Collections.Generic;

namespace FirstTask
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> iterateCollection;

        private int internalIndex;

        public ListyIterator()
        {
            this.iterateCollection = new List<T>();
            this.internalIndex = 0;
        }

        public bool Move()
        {
            this.internalIndex++;

            if (this.iterateCollection.Count > this.internalIndex)
            {
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            int nextIndex = this.internalIndex + 1;

            if (this.iterateCollection.Count > nextIndex)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.iterateCollection.Count > 0)
            {
                Console.WriteLine($"{this.iterateCollection[this.internalIndex]}");
            }
            else
            {
                throw new ArgumentException("Invalid Operation!");
            }
        }

        public void PrintAll()
        {
            foreach (var item in this.iterateCollection)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        public void Add(T element)
        {
            this.iterateCollection.Add(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.iterateCollection.Count; i++)
            {
                yield return this.iterateCollection[i];

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}