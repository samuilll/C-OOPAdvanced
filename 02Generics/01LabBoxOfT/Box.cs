using System;
using System.Collections.Generic;
using System.Text;


   public class Box<T>
    {

    private readonly List<T> items;

    public Box()
    {
        this.items = new List<T>();
    }

    public int Count
    {
        get
        {
            return this.items.Count;
        }
    }
    public void Add(T item)
    {
        this.items.Add(item);
    }
    public T Remove()
    {
        T element = this.items[this.items.Count-1];

        this.items.RemoveAt(this.items.Count - 1);

        return element;
    }
    }

