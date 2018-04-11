using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


  public  class Sorter<T>
    where T:IComparable<T>
    {

    public static void Sort(ICustomList<T> data)
    {       
        data.Elements = data.Elements.OrderBy(e=>e).ToArray();
    }
    }

