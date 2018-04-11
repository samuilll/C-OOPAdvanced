using Ex04WorkForce.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ex04WorkForce.Factories
{
    public class EmployeeFactory
    {
        public IEmployee CreateEmployee(string typeAsString,string name)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeAsString);

            if (type==null)
            {
                throw new ArgumentException("Invalid employee type!");
            }

            IEmployee employee =(IEmployee) Activator.CreateInstance(type, new object[] { name });

            return employee;
        }
    }
}
