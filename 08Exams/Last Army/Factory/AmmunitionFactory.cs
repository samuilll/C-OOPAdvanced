using System;
using System.Linq;
using System.Reflection;


    public class AmmunitionFactory:IAmmunitionFactory
    {
       
        public   IAmmunition CreateAmmunition(string name)
        {
            
                Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == name);
        
                IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(type,name);

                return ammunition;       
        }

 
    }
