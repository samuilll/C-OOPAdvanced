using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class ListIterator<T>:IEnumerable<T>
{

    public ListIterator(IEnumerable<T> data)
    {
        this.data = new List<T>(data);
        this.index = 0;
    }
    private IReadOnlyList<T> data;
    public T Current => this.data[index];

    private int index;


    public bool Move()
    {
        if (this.index<this.data.Count-1)
        {
            this.index++;
        }
        else
        {
            return false;
        }

        return true;
    }

    public bool HasNext()
    {
        return this.index+1 < this.data.Count;
    }

    public void Print()
    {
        HasElementsValidation();
        Console.WriteLine(this.data[this.index]);
    }

    private void HasElementsValidation()
    {
        if (this.data.Count == 0 || this.index >= this.data.Count)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }

    internal void PrintAll()
    {
        HasElementsValidation();

        foreach (var item in this)
        {
            Console.Write(item+" ");
        }
        Console.WriteLine();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.data.Count; i++)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

