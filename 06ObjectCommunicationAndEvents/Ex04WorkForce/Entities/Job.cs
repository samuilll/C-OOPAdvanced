using Ex04WorkForce.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WorkForce.Entities
{
   public class Job : IJob
    {
        public Job(IEmployee employee, string name, int hoursOfWorkRequired)
        {
            this.Employee = employee;
            this.Name = name;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
        }

        public IEmployee Employee { get; private set; }

        public string Name { get; private set; }

        public int HoursOfWorkRequired { get; private set; }

        public void SubstractHours()
        {
            this.HoursOfWorkRequired -= this.Employee.WorkHoursPerWeek;
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
        }
    }
}
