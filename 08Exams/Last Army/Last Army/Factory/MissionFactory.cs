using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == difficultyLevel);

        if (type == null)
        {
            throw new ArgumentException("No such a class");
        }
        if (!typeof(IMission).IsAssignableFrom(type))
        {
            throw new ArgumentException("No such a mission");
        }

        IMission mission = (IMission)Activator.CreateInstance(type, neededPoints);

        return mission;
    }
}

