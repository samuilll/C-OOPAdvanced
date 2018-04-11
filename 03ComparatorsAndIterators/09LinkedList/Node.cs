using System;
using System.Collections.Generic;
using System.Text;


  public  class Node<T>
    {
    public Node(T item)
    {
        this.Item = item;
    }

    public T Item { get; set; }

    public Node<T> Next { get; set; }

    public Node<T> Prev { get; set; }

    public override string ToString()
    {
        return this.Item.ToString();
    }
}

