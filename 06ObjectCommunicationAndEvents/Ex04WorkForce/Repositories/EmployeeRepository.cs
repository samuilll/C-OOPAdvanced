using Ex04WorkForce.Contracts;
using Ex04WorkForce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04WorkForce.Repositories
{
    public class EmployeeRepository
    {

        private ICollection<IEmployee> employees;

        public EmployeeRepository()
        {
            this.employees = new List<IEmployee>();
        }

        public IReadOnlyCollection<IEmployee> Employees => (IReadOnlyCollection<IEmployee>)employees;

        public void AddEmployee(IEmployee employee)
        {
            this.employees.Add(employee);
        }
        


    }
}
