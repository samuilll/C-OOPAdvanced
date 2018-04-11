using System;
using System.Collections.Generic;
using System.Text;

namespace _07Hack
{
    public class Abs : IAbs
    {
       public double Absolute(double value)
        {
            return Math.Abs(value);
        }
    }
}
