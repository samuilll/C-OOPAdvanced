
using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == ammunitionName);

        if (type == null)
        {
            throw new ArgumentException("No such a class");
        }
        if (!typeof(IAmmunition).IsAssignableFrom(type))
        {
            throw new ArgumentException("No such a ammo");
        }

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(type);

        return ammunition;
    }
}