using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public  class Stack<T>:IEnumerable<T>
    {

    private  IList<T> items;
   
    public Stack()
    {
        this.items = new List<T>();
    }

    public void Push(IEnumerable<T> itemsToAdd)
    {
        foreach (var item in itemsToAdd)
        {
            this.items.Add(item);
        }
    }
    public T Pop()
    {
        if (this.items.Count==0)
        {
            throw new ArgumentException("No elements");
        }
        T item = this.items[this.items.Count - 1];

        this.items.RemoveAt(this.items.Count - 1);

        return item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.items.Count-1; i>=0; i--)
        {
            yield return this.items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

