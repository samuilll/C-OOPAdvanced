using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


    public class SoldiersFactory:ISoldierFactory
    {
      
        public  ISoldier CreateSoldier(string typeName,string name, int age, double experience, double endurance)
        {
            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);

            ISoldier soldier = (ISoldier)Activator.CreateInstance(type,name, age, experience, endurance );

            return soldier;
        }

    }
