using Ex04WorkForce.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ex04WorkForce.Factories
{
   public class JobFactory
    {

        public IJob CreateJob(string name, int hours,IEmployee employee)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == "Job");

            if (type == null)
            {
                throw new ArgumentException("Invalid employee type!");
            }

            IJob job = (IJob)Activator.CreateInstance(type, new object[] { employee,name,hours });

            return job;
        }
    }
}
