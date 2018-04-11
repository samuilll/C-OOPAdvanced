using System;
using System.Collections.Generic;
using System.Text;


public class SecondComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Age.CompareTo(y.Age);

        return result;
    }
}

