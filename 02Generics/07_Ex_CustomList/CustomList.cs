using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CustomList<T> : ICustomList<T>,IEnumerable<T>
    where T : IComparable<T>
{

    private const int initialCapacity = 16;
   
    public T[] Elements
    {
        get
        {
            return this.data.Take(this.length).ToArray(); ;
        }
        set
        {
            this.data = value;
        }
    }

    private int length;

    private T[] data;

    public CustomList()
    {
        this.data = new T[initialCapacity];
    }
    public CustomList(T[] list)
    {
        this.data =list;
    }

    public void Add(T element)
    {
        if (this.length == this.data.Length)
        {
            this.data = this.data.Concat(new T[this.length]).ToArray();
        }
        this.data[length] = element;

        this.length++;

    }

    private T this[int index]
    {
        get
        {
            return this.data[index];
        }

    }
    public bool Contains(T element)
    {
        bool haveElement = false;

        for (int i = 0; i < this.length; i++)
        {
            if (this.data[i].CompareTo(element) == 0)
            {
                return true;
            }
        }

        return haveElement;
    }

    public int CountGreaterThan(T element)
    {
        int counter = 0;

        for (int i = 0; i < this.length; i++)
        {
            if (this.data[i].CompareTo(element) > 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public T Max()
    {
        if (this.data.Length == 0)
        {
            throw new ArgumentException();
        }

        T max = this.data[0];

        for (int i = 0; i < this.length; i++)
        {
            if (this.data[i].CompareTo(max) > 0)
            {
                max = this.data[i];
            }
        }
        return max;
    }

    public T Min()
    {
        if (this.data.Length == 0)
        {
            throw new ArgumentException();
        }

        T min = this.data[0];

        for (int i = 0; i < this.length; i++)
        {
            if (this.data[i].CompareTo(min) < 0)
            {
                min = this.data[i];
            }
        }
        return min;
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= this.data.Length)
        {
            throw new ArgumentException();
        }

        T element = this.data[index];

        this.data = this.data.Take(index).Concat(this.data.Skip(index + 1)).ToArray();

        this.length--;

        return element;
    }

   

    public void Swap(int firstIndex, int secondIndex)
    {
        T tempElement = this.data[firstIndex];
        this.data[firstIndex] = this.data[secondIndex];
        this.data[secondIndex] = tempElement;
    }
  
    IEnumerator IEnumerable.GetEnumerator()
    {
      return   this.GetEnumerator();
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.length; i++)
        {
            yield return this.data[i];
        }
    }   
}

