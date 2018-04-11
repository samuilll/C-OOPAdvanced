using System;
using System.Collections.Generic;
using System.Text;


class GenericBox<T>
{

    public GenericBox(T value)
    {
        this.value = value;
    }

    private T value;

    public override string ToString()
    {
        string result = $"{this.value.GetType()}: {this.value}";

        return result; ;
    }
}

