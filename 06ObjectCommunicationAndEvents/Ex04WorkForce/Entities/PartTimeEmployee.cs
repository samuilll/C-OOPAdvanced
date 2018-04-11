using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WorkForce.Entities
{
  public  class PartTimeEmployee:Employee
    {
        private const int hoursPerWeek = 20;

        public PartTimeEmployee(string name) : base(name, hoursPerWeek)
        {
        }

       

    }
}
