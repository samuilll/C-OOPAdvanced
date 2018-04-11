using System;
using System.Collections.Generic;
using System.Text;


public class Tuple<Tfirst, Tsecond, Tthird>
{


    private Tfirst item1;
    private Tsecond item2;
    private Tthird item3;
    public Tuple(Tfirst firstElement, Tsecond seondElement, Tthird thirdElement)
    {
        this.item1 = firstElement;
        this.item2 = seondElement;
        this.item3 = thirdElement;
    }

    public override string ToString()
    {
        return $"{this.item1} -> {this.item2} -> {this.item3}";
    }
}

