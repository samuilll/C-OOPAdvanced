using System;
using System.Collections.Generic;
using System.Text;


  public  class SwapableCollection<T>
    {
    public SwapableCollection()
    {
        this.items = new List<T>();
    }
    private IList<T> items;

    public IReadOnlyCollection<T> Items =>(IReadOnlyCollection<T>) this.items;

    public void AddItem(T item)
    {
        this.items.Add(item);
    }
    public void Swap(int firstIndex, int secondIndex)
    {
        T tempElement = this.items[firstIndex];
        this.items[firstIndex] = this.items[secondIndex];
        this.items[secondIndex] = tempElement;
    }

    }

