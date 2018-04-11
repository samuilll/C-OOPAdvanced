using System;
using System.Collections.Generic;
using System.Text;


  public  class SpecificElementsCounter<T>
    where T: IComparable<T>
    {


    public int Count(IList<T> data, T specificItem)
    {
        int counter = 0;

        foreach (var item in data)
        {
            if (item.CompareTo(specificItem)>0)
            {
                counter++;
            }
        }

        return counter;
    }
    }

