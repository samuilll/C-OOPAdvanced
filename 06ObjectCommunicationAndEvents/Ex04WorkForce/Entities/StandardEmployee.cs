using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WorkForce.Entities
{
  public  class StandardEmployee:Employee
    {
        private const int hoursPerWeek = 40;

        public StandardEmployee(string name) : base(name, hoursPerWeek)
        {
        }
    }
}
