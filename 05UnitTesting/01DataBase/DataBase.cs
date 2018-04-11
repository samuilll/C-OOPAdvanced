using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01DataBase
{
    public class DataBase<T>
    {
        protected  T[] array;


        private const int arrayCapacity = 16;

        protected int currentIndex;

        public int Count => this.currentIndex;

        public int ArraySize => this.array.Length;
        public T this[int index]
        {

            get => this.array[index];

            protected set
            {
                this.array[index] = value;
            }
        }

        public DataBase(params T[] items)
        {
            if (items.Length>16)
            {
                throw new InvalidOperationException("Wrong array size!");
            }

            this.array = new T[arrayCapacity];

            AddInitialItems(items);
        }

        private void AddInitialItems(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                this.AddItem(items[i]);
            }
        }

        public virtual void AddItem(T item)
        {
            if (this.currentIndex == arrayCapacity)
            {
                throw new InvalidOperationException("There are no more free cells!");
            }

            this[this.currentIndex] = item;

            this.currentIndex++;
        }
        public virtual void RemoveItem()
        {
            if (this.currentIndex <=0)
            {
                throw new InvalidOperationException("There are no  elements in the array");
            }

            this[this.currentIndex-1] = default(T);

            this.currentIndex--;
        }

        public string Fetch()
        {
            return string.Join(", ", this.array.Take(this.currentIndex));
        }
    }
}
