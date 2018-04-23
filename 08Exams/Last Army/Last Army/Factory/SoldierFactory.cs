using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SoldierFactory:ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == soldierTypeName);

        if (type == null)
        {
            throw new ArgumentException("No such a class");
        }
        if (!typeof(ISoldier).IsAssignableFrom(type))
        {
            throw new ArgumentException("No such a soldier");
        }

        ISoldier soldier = (ISoldier)Activator.CreateInstance(type, name, age, experience, endurance);

        return soldier;
    }

}
