using System;
using System.Collections.Generic;
using System.Text;


public class Scale<T>
    where T : IComparable<T>
{

    public Scale(T left, T right)
    {
        this.left = left;
        this.right = right;
    }
    private T left;
    private T right;

    public T GetHeavier()
    {
        int compareResult = this.left.CompareTo(this.right);

        return compareResult > 0 ? this.left: compareResult < 0? this.right : default(T);
    }
}

