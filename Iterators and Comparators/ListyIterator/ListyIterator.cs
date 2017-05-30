using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FirstTask
{
    public class ListyIterator<T>
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

        public void Add(T element)
        {
            this.iterateCollection.Add(element);
        }
    }
}