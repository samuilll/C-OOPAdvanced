using BashSoft.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.DataStrucures
{
    public class SimpleSortedList<T> : ISimpleOrderedBag<T>
          where T : IComparable<T>
    {
        public SimpleSortedList(IComparer<T> comparison, int capacity)
        {
            this.comparison = comparison;
            this.InitializeInnerCollection(capacity);
        }
        public SimpleSortedList(int capacity)
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList(IComparer<T> comparison) : this(comparison, defaultSize)
        {

        }
        public SimpleSortedList() : this(defaultSize)
        {

        }
        private const int defaultSize = 16;

        private T[] innerCollection;
        private int size;
        private IComparer<T> comparison;

        public int Size => this.size;

        public int Capacity => this.innerCollection.Length;

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.innerCollection = new T[capacity];
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            if (this.innerCollection.Length==this.Size)
            {
                this.Resize();
            }
            this.innerCollection[size] = element;
            this.size++;
            Array.Sort(this.innerCollection,0,size,this.comparison);
        }

        private void Resize()
        {
            T[] newCollection = new T[this.Size*2];
            Array.Copy(this.innerCollection,newCollection,this.Size);
            this.innerCollection = newCollection;
        }

        public void AddAll(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }
            if (this.Size+collection.Count>=this.innerCollection.Length)
            {
                this.MultiResize(collection);
            }

            foreach (var item in collection)
            {
                this.innerCollection[size] = item;
                this.size++;
            }

            Array.Sort(this.innerCollection, 0, size, this.comparison);
        }

        private void MultiResize(ICollection<T> collection)
        {
            int newSize = this.innerCollection.Length * 2;

            while (newSize<=this.size+collection.Count)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.Size);
            this.innerCollection = newCollection;
        }

        public string JoinWith(string joiner)
        {
            if (joiner == null)
            {
                throw new ArgumentNullException();
            }
            StringBuilder builder = new StringBuilder();

            foreach (var element in this)
            {
                builder.Append(element);
                builder.Append(joiner);
            }
            builder.Remove(builder.Length -joiner.Length, joiner.Length);

            return builder.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            bool hasBeenRemoved = false;
            int indexOfRemovedElement = 0;

            for (int i = 0; i < this.Size; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfRemovedElement = i;
                    this.innerCollection[i] = default(T);
                    hasBeenRemoved = true;
                    this.size--;
                    break;
                }
            }

            if (hasBeenRemoved)
            {
                for (int i = indexOfRemovedElement; i < this.Size; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                }

                this.innerCollection[this.size - 1] = default(T);
            }

            return hasBeenRemoved;
        }
    }
}
