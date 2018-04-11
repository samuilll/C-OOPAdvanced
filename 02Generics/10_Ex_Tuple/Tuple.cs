using System;
using System.Collections.Generic;
using System.Text;


public class Tuple<Tfirst, Tsecond>
{


    private Tfirst item1;
    private Tsecond item2;
    public Tuple(Tfirst firstElement, Tsecond seondElement)
    {
        this.item1 = firstElement;
        this.item2 = seondElement;
    }

    public override string ToString()
    {
        return $"{this.item1} -> {this.item2}";
    }
}

