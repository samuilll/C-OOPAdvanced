using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WorkForce.Contracts
{
   public interface IEmployee
    {
        string Name { get; }

        int WorkHoursPerWeek { get; }
    }
}
