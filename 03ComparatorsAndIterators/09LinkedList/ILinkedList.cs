using System;
using System.Collections.Generic;
using System.Text;


    public interface ILinkedList<T>:IEnumerable<T>
    {

    int Count { get; }

    void Add(T item);
    bool Remove(T item);
    }

