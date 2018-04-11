using Ex04WorkForce.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WorkForce.Entities
{
    public abstract class Employee : IEmployee
    {
        protected Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }

        public string Name { get; protected set; }

        public int WorkHoursPerWeek { get; protected set;}
    }
}
