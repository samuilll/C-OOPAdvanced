using System;
using System.Collections.Generic;
using System.Text;

namespace _07Hack
{
    public class Floor : IFloor
    {
        public double ToFloor(double value)
        {
            return Math.Floor(value);
        }
    }
}
