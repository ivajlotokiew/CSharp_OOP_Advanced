using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomStack
{
    public class StackCollection<T> : IEnumerable<T>
    {
        private const int InitializationCapacity = 8;
        private T[] arrayCollection;

        public StackCollection()
        {
            this.Capacity = InitializationCapacity;
            this.Count = 0;
            this.arrayCollection = new T[this.Capacity];
        }

        public int Count { get; set; }

        public int Capacity { get; set; }

        public void Push(T element)
        {
            this.arrayCollection[this.Count] = element;
            this.Count++;

            if (this.Count >= this.Capacity)
            {
                Resize();
            }
        }

        public void Pop()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException("No elements");
            }

            int lastIndex = this.Count - 1;
            this.arrayCollection[lastIndex] = default(T);
            this.Count--;
        }

        private void Resize()
        {
            this.Capacity *= 2;
            T[] newArray = new T[this.Capacity];
            Array.Copy(this.arrayCollection, newArray, this.Capacity);

            this.arrayCollection = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.arrayCollection[i];
            }
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.arrayCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}